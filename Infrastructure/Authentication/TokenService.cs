using Application.Abstraction;
using Application.Abstraction.Authentication;
using Application.Configurations;
using Application.Time;
using Application.Entity.DTOs;
using Domain.Entities.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Authentication
{
    internal sealed class TokenService(
        IOptions<JwtSettings> jwtSettings,
        IOptions<AuthenticationSettings> authenticationSettings,
        IDateTimeProvider dateTimeProvider,
        IEntityContext userContext) : ITokenService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;
        private readonly AuthenticationSettings _authenticationSettings = authenticationSettings.Value;
        private readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
        private readonly IEntityContext _userContext = userContext;

        public LoginEntityResponse GenerateAccessTokenAsync(Entity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>();

            foreach(var userClaim in user.Claims)
            {
                claims.Add(new Claim(userClaim.ClaimType, userClaim.ClaimValue));
            }

            foreach (var userRole in user.EntityRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.RoleId.ToString()));
            }
            var tokenExpiration = _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.TokenExpiration);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiration,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginEntityResponse()
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = GenerateRefreshToken(),
                ExpiresIn = tokenExpiration
            };
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        public bool ValidateRefreshTokenAsync(Entity user, string refreshToken)
        {
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }

        public bool RevokeRefreshTokenAsync(Entity user)
        {
            if (user == null) return false;

            user.RefreshToken = null;
            return true;
        }

        public EntityVerifications GenerateUserVerifications(Entity user, string verificationType)
        {
            var code = GenerateNumericCode(6);
            var referenceId = Guid.NewGuid().ToString();

            return new EntityVerifications()
            {
                ReferenceId = referenceId,
                Code = code,
                VerificationCodeType = verificationType,
                CreatedDate = _dateTimeProvider.UtcNow,
                ExpiryDate = _dateTimeProvider.UtcNow.AddMinutes(_authenticationSettings.VerificationCodeTime),
                IsUsed = false,
                IpAddress = _userContext.IpAddress(),
                EntityId = user.Id
            };
        }

        private string GenerateNumericCode(int length)
        {
            var byteArray = new byte[length];
            _rng.GetBytes(byteArray);

            var code = new StringBuilder(length);
            foreach (var b in byteArray)
            {
                code.Append((b % 10).ToString());
            }

            return code.ToString();
        }
    }
}

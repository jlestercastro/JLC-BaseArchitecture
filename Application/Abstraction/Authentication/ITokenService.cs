using Application.Entity.DTOs;
using Domain.Entities.Identity;
using System.Security.Claims;

namespace Application.Abstraction.Authentication
{
    public interface ITokenService
    {
        LoginEntityResponse GenerateAccessTokenAsync(Domain.Entities.Identity.Entity user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        bool RevokeRefreshTokenAsync(Domain.Entities.Identity.Entity user);
        bool ValidateRefreshTokenAsync(Domain.Entities.Identity.Entity user, string refreshToken);
        EntityVerifications GenerateUserVerifications(Domain.Entities.Identity.Entity user, string verificationType);
    }
}

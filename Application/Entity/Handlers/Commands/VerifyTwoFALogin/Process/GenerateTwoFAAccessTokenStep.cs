using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.VerifyTwoFALogin.Process
{
    internal sealed class GenerateTwoFAAccessTokenStep : Step<VerifyTwoFAContext, Result<VerifyTwoFAResponse>>
    {
        public override async Task<Result<VerifyTwoFAResponse>> ExecuteAsync(VerifyTwoFAContext context)
        {
            var loginResponse = context.TokenService.GenerateAccessTokenAsync(context.User);

            context.User.RefreshToken = loginResponse.RefreshToken;
            context.User.RefreshTokenExpiryTime = context.DateTimeProvider.UtcNow.AddDays(context.JwtSettings.RefreshTokenLifetimeDays);

            context.Result.Value.AccessToken = loginResponse.AccessToken;
            context.Result.Value.ExpiresIn = loginResponse.ExpiresIn;
            context.Result.Value.RefreshToken = loginResponse.RefreshToken;

            context.UnitOfWork.EntityRepository.Update(context.User);

            // Add AppLog User Login by 2FA
            return await this.ExecuteNextAsync(context);
        }
    }
}

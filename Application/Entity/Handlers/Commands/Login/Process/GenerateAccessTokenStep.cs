using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    internal sealed class GenerateAccessTokenStep : Step<LoginUserContext, Result<LoginEntityResponse>>
    {
        public override async Task<Result<LoginEntityResponse>> ExecuteAsync(LoginUserContext context)
        {
            var loginResponse = context.TokenService.GenerateAccessTokenAsync(context.User);

            context.User.RefreshToken = loginResponse.RefreshToken;
            context.User.RefreshTokenExpiryTime = context.DateTimeProvider.UtcNow.AddDays(context.JwtSettings.RefreshTokenLifetimeDays);
            context.Result.Value.AccessToken = loginResponse.AccessToken;
            context.Result.Value.ExpiresIn = loginResponse.ExpiresIn;
            context.Result.Value.UserId = context.User.Id;

            context.UnitOfWork.EntityRepository.Update(context.User);

            // Add AppLog User success login
            context.AppLogService.LogInformation(string.Format("{0} Successful LOGIN", context.User.UserName));
            return await this.ExecuteNextAsync(context);
        }
    }
}

using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    internal sealed class Send2FAAuthenticationCodeStep : Step<LoginUserContext, Result<LoginEntityResponse>>
    {
        public override async Task<Result<LoginEntityResponse>> ExecuteAsync(LoginUserContext context)
        {
            if (context.User.TwoFactorEnabled && context.IsVerified)
            {
                // Send SMS message for 2FA code.
            }

            return await this.ExecuteNextAsync(context);
        }
    }
}

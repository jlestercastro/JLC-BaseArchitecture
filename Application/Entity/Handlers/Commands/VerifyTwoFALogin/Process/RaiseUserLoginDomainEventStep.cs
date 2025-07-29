using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Events.Identity;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.VerifyTwoFALogin.Process
{
    internal sealed class RaiseUserLoginDomainEventStep : Step<VerifyTwoFAContext, Result<VerifyTwoFAResponse>>
    {
        public override async Task<Result<VerifyTwoFAResponse>> ExecuteAsync(VerifyTwoFAContext context)
        {
            context.User.Raise(new UserLoginDomainEvent(context.User));

            return await this.ExecuteNextAsync(context);
        }
    }
}

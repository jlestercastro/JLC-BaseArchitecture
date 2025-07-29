using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Domain.Events.Identity;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login.Process
{
    internal sealed class RaiseUserLoginDomainEventStep : Step<LoginUserContext, Result<LoginEntityResponse>>
    {
        public override async Task<Result<LoginEntityResponse>> ExecuteAsync(LoginUserContext context)
        {
            context.User.Raise(new UserLoginDomainEvent(context.User));

            return await this.ExecuteNextAsync(context);
        }
    }
}

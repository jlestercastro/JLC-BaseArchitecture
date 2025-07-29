using Application.Abstraction.Steps;
using Application.Entity.DTOs;
using Application.Entity.Handlers.Commands.Register.Context;
using Domain.Events.Identity;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Register.Process
{
    internal class RaiseUserRegisterDomainEventStep : Step<RegisterUserContext, Result<RegisterResponse>>
    {
        public override async Task<Result<RegisterResponse>> ExecuteAsync(RegisterUserContext context)
        {
            context.User.Raise(new UserRegisteredDomainEvent(context.User));

            await context.UnitOfWork.EntityRepository.AddAsync(context.User);

            return await this.ExecuteNextAsync(context);
        }
    }
}

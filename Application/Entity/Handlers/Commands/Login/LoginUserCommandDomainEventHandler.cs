using Domain.Events.Identity;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Login
{
    internal sealed class LoginUserCommandDomainEventHandler : IDomainEventHandler<UserLoginDomainEvent>
    {
        public Task Handle(UserLoginDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            // TODO: Send Login email notification
            return Task.CompletedTask;
        }
    }
}

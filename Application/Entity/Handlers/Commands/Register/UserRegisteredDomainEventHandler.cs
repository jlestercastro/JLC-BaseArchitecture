using Domain.Events.Identity;
using Domain.Primitives;

namespace Application.Entity.Handlers.Commands.Register
{
    internal sealed class UserRegisteredDomainEventHandler : IDomainEventHandler<UserRegisteredDomainEvent>
    {
        public Task Handle(UserRegisteredDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            // TODO: Send an email verification link, etc.
            return Task.CompletedTask;
        }
    }
}

using Domain.Entities.Identity;
using Domain.Primitives;

namespace Domain.Events.Identity
{
    public sealed record UserRegisteredDomainEvent(Entity user) : IDomainEvent;
}

using Domain.Entities.Identity;
using Domain.Primitives;

namespace Domain.Events.Identity
{
    public sealed class UserLoginDomainEvent(Entity user) : IDomainEvent;
}

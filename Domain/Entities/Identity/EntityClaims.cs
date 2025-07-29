using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityClaims : BaseEntity<Guid>
    {
        public string ClaimType { get; set; } = default!;
        public string ClaimValue { get; set; } = default!;

        public virtual Guid EntityId { get; set; }
        public virtual Entity Entity { get; set; } = default!;
    }
}

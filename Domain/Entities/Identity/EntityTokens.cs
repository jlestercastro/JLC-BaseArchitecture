using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityTokens : BaseEntity<Guid>
    {
        public string LoginProvider { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Value { get; set; } = default!;

        public virtual Guid EntityId { get; set; }
        public virtual Entity Entity { get; set; } = default!;
    }
}

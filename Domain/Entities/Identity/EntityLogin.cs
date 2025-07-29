using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityLogin : BaseEntity<Guid>
    {
        public string LoginProvider { get; set; } = default!;
        public string ProviderKey { get; set; } = default!;
        public string ProviderDisplayName { get; set; } = default!;

        public virtual Guid EntityId { get; set; }
        public virtual Entity Entity { get; set; } = default!;
    }
}

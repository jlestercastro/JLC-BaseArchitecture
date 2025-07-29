using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityRoles : BaseEntity<Guid>
    {
        public virtual Guid EntityId { get; set; } = default!;
        public virtual Guid RoleId { get; set; } = default!;
        public virtual Entity? Entity { get; set; }
        public virtual Roles? Role { get; set; }
    }
}

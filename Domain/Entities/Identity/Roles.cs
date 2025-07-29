using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class Roles : BaseEntity<Guid>
    {
        public string Name { get; set; } = default!;
        public string NormalizedName { get; set; } = default!;
        public string ConcurrencyStamp { get; set; } = default!;
        public virtual ICollection<EntityRoles>? UserRoles { get; set; }
        public virtual ICollection<RoleClaims>? RoleClaims { get; set; }
    }
}

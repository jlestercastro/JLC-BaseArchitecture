using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class RoleClaims : BaseEntity<Guid>
    {
        public string ClaimType { get; set; } = default!;
        public string ClaimValue { get; set; } = default!;

        public virtual Guid RoleId { get; set; }
        public virtual Roles? Role { get; set; }
    }
}

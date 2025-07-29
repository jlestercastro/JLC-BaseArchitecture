using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class Entity : BaseEntity<Guid>
    {
        public string UserName { get; set; } = default!;
        public string NormalizedUserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string NormalizedEmail { get; set; } = default!;
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; } = default!;
        public string SecurityStamp { get; set; } = default!;
        public string ConcurrencyStamp { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockOutEnd { get; set; }
        public bool LockOutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string RefreshToken { get; set; } = default!;
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public virtual EntityInformations? EntityInformation { get; set; }

        public virtual ICollection<EntityClaims> Claims { get; set; } = default!;
        public virtual ICollection<EntityLogin> Logins { get; set; } = default!;
        public virtual ICollection<EntityTokens> Tokens { get; set; } = default!;
        public virtual ICollection<EntityRoles> EntityRoles { get; set; } = default!;
        public virtual ICollection<EntityVerifications> EntityVerifications { get; set; } = default!;
    }
}

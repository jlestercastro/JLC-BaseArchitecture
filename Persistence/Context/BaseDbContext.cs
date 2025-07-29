using Microsoft.EntityFrameworkCore.Storage;

namespace Persistence.Context
{
    public abstract class BaseDbContext(DbContextOptions options) : DbContext(options), IDisposable
    {
        #region Identity Table
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<RoleClaims> RoleClaims { get; set; } = default;
        public DbSet<Roles> Roles { get; set; } = default;
        public DbSet<EntityAddress> UserAddresses { get; set; } = default!;
        public DbSet<EntityContacts> UserContacts { get; set; }
        public DbSet<EntityInformations> UserInformations { get; set; }
        public DbSet<EntityLogin> UserLogins { get; set; } = default;
        public DbSet<Entity> Users { get; set; } = default;
        public DbSet<EntityRoles> UserRoles { get; set; } = default;
        public DbSet<EntityTokens> UserTokens { get; set; } = default;
        #endregion

        #region Lv Table
        public DbSet<LvAddressType> LvAddressTypes { get; set; }
        public DbSet<LvContactType> LvContactTypes { get; set; }

        #endregion

        #region Logging Table
        public DbSet<AppLog> AppLog { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        //public DbSet<ErrorLog> ErrorLog { get; set; }
        //public DbSet<DomainEventLog> EventLog { get; set; }
        #endregion
    }
}

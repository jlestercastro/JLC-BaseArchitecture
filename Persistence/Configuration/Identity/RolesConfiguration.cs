namespace Persistence.Configuration.Identity
{
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable(name: RoleConfigurationConstants.TableName);

            builder.HasKey(a => a.Id);

            builder.HasIndex(r => r.NormalizedName).IsUnique();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name)
                .HasColumnName(nameof(Roles.Name))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(RoleConfigurationConstants.NameMaxLength);

            builder.Property(u => u.NormalizedName)
                .HasColumnName(nameof(Roles.NormalizedName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(RoleConfigurationConstants.NormalizedNameMaxLength);

            builder.Property(u => u.ConcurrencyStamp)
                .HasColumnName(nameof(Roles.ConcurrencyStamp))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(RoleConfigurationConstants.ConcurrencyStampMaxLength)
                .IsConcurrencyToken();

            // Each Role can have many entries in the UserRole join table
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();

            builder.AddSeedData();
        }
    }
}

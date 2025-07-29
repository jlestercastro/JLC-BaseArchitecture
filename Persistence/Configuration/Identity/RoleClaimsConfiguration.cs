namespace Persistence.Configuration.Identity
{
    public class RoleClaimsConfiguration : IEntityTypeConfiguration<RoleClaims>
    {
        public void Configure(EntityTypeBuilder<RoleClaims> builder)
        {
            builder.ToTable(name: RoleClaimsConfigurationConstants.TableName);
            builder.HasKey(a => new { a.Id });

            builder.Property(a => a.ClaimType)
                .HasColumnName(nameof(RoleClaims.ClaimType))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(RoleClaimsConfigurationConstants.ClaimTypeMaxLength);

            builder.Property(a => a.ClaimValue)
                .HasColumnName(nameof(RoleClaims.ClaimValue))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(RoleClaimsConfigurationConstants.ClaimValueMaxLength);
        }
    }
}

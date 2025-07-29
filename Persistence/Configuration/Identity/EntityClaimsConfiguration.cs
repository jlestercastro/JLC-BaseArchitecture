namespace Persistence.Configuration.Identity
{
    public class EntityClaimsConfiguration : IEntityTypeConfiguration<EntityClaims>
    {
        public void Configure(EntityTypeBuilder<EntityClaims> builder)
        {
            builder.ToTable(name: EntityClaimsConfigurationConstants.TableName);
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ClaimType)
                .HasColumnName(nameof(RoleClaims.ClaimType))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityClaimsConfigurationConstants.ClaimTypeMaxLength);

            builder.Property(a => a.ClaimValue)
                .HasColumnName(nameof(RoleClaims.ClaimValue))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityClaimsConfigurationConstants.ClaimValueMaxLength);

            builder.HasOne(a => a.Entity)
                .WithMany()
                .HasForeignKey(a => a.EntityId)
                .IsRequired();
        }
    }
}

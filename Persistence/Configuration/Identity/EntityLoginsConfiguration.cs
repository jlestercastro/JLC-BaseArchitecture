namespace Persistence.Configuration.Identity
{
    public class EntityLoginsConfiguration : IEntityTypeConfiguration<EntityLogin>
    {
        public void Configure(EntityTypeBuilder<EntityLogin> builder)
        {
            builder.ToTable(name: EntityLoginsConfigurationConstants.TableName);
            builder.HasKey(l => new { l.EntityId, l.LoginProvider, l.ProviderKey });

            builder.Property(l => l.LoginProvider)
                .HasColumnName(nameof(EntityLogin.LoginProvider))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityLoginsConfigurationConstants.LoginProviderMaxLength);

            builder.Property(l => l.ProviderKey)
                .HasColumnName(nameof(EntityLogin.ProviderKey))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityLoginsConfigurationConstants.ProviderKeyMaxLength);

            builder.Property(l => l.ProviderDisplayName)
                .HasColumnName(nameof(EntityLogin.ProviderDisplayName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityLoginsConfigurationConstants.ProviderDisplayNameMaxLength);

            builder.HasOne(a => a.Entity)
                .WithMany(a => a.Logins)
                .HasForeignKey(a => a.EntityId)
                .IsRequired();
        }
    }
}

namespace Persistence.Configuration.Identity
{
    public class EntityTokensConfiguration : IEntityTypeConfiguration<EntityTokens>
    {
        public void Configure(EntityTypeBuilder<EntityTokens> builder)
        {
            builder.ToTable(name: EntityTokensConfigurationConstants.TableName);
            builder.HasKey(t => new { t.EntityId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.LoginProvider)
                .HasColumnName(nameof(EntityTokens.LoginProvider))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityTokensConfigurationConstants.LoginProviderMaxLength);

            builder.Property(t => t.Name)
                .HasColumnName(nameof(EntityTokens.Name))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityTokensConfigurationConstants.NameMaxLength);

            builder.Property(t => t.Value)
                .HasColumnName(nameof(EntityTokens.Value))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityTokensConfigurationConstants.ValueMaxLength);

            builder.HasOne(a => a.Entity)
                .WithMany(a => a.Tokens)
                .HasForeignKey(a => a.EntityId)
                .IsRequired();
        }
    }
}

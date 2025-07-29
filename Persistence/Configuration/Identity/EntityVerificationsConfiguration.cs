namespace Persistence.Configuration.Identity
{
    public class EntityVerificationsConfiguration : IEntityTypeConfiguration<EntityVerifications>
    {
        public void Configure(EntityTypeBuilder<EntityVerifications> builder)
        {
            builder.ToTable(name: VerificationCodesConfigurationConstants.TableName);

            builder.HasKey(a => a.Id);
            builder.HasIndex(a => new { a.Code, a.EntityId, a.VerificationCodeType });

            builder.Property(a => a.Code)
                .HasColumnName(nameof(EntityVerifications.Code))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(VerificationCodesConfigurationConstants.CodeMaxLength)
                .IsRequired();

            builder.Property(a => a.VerificationCodeType)
                .HasColumnName(nameof(EntityVerifications.VerificationCodeType))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(VerificationCodesConfigurationConstants.VerificationCodeTypeMaxLength)
                .IsRequired();

            builder.Property(a => a.CreatedDate)
                .HasColumnName(nameof(EntityVerifications.CreatedDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2)
                .HasDefaultValueSql(SqlDefaultConstants.SqlDateTimeDefaultValue);

            builder.Property(a => a.ExpiryDate)
                .HasColumnName(nameof(EntityVerifications.ExpiryDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2)
                .HasComputedColumnSql("DATEADD(minute, 15, CreatedDate)");

            builder.Property(a => a.IsUsed)
                .HasColumnName(nameof(EntityVerifications.IsUsed))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .HasDefaultValue(false);

            builder.Property(a => a.IpAddress)
                .HasColumnName(nameof(EntityVerifications.IpAddress))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(VerificationCodesConfigurationConstants.IpAddressMaxLength)
                .IsRequired(false);

            builder.Property(a => a.AdditionalData)
                .HasColumnName(nameof(EntityVerifications.AdditionalData))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(VerificationCodesConfigurationConstants.AdditionalDataMaxLength)
                .IsUnicode()
                .IsRequired(false);

            builder.HasOne(a => a.LvVerificationCodeType)
                .WithMany()
                .HasForeignKey(a => a.VerificationCodeType)
                .HasPrincipalKey(a => a.Code)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

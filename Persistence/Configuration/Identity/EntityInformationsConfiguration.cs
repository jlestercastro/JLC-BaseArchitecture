namespace Persistence.Configuration.Identity
{
    public class EntityInformationsConfiguration : IEntityTypeConfiguration<EntityInformations>
    {
        public void Configure(EntityTypeBuilder<EntityInformations> builder)
        {
            builder.ToTable(name: EntityInformationConfigurationConstants.TableName);
            builder.HasKey(a => new { a.Id });

            builder.Property(a => a.Id)
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier)
                .HasDefaultValueSql(SqlDefaultConstants.SqlGuidDefaultValue);

            builder.Property(a => a.EntityId)
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.IsIndividual)
                .HasColumnName(nameof(EntityInformations.IsIndividual))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .IsRequired();

            builder.Property(a => a.FirstName)
                .HasColumnName(nameof(EntityInformations.FirstName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityInformationConfigurationConstants.FirstNameMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false); ;

            builder.Property(a => a.MiddleName)
                .HasColumnName(nameof(EntityInformations.MiddleName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityInformationConfigurationConstants.MiddleNameMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false); ;

            builder.Property(a => a.LastName)
                .HasColumnName(nameof(EntityInformations.LastName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityInformationConfigurationConstants.LastNameMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false); ;

            builder.Property(a => a.Suffix)
                .HasColumnName(nameof(EntityInformations.Suffix))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityInformationConfigurationConstants.SuffixMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false);

            builder.Property(a => a.Gender)
                .HasColumnName(nameof(EntityInformations.Gender))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityInformationConfigurationConstants.GenderMaxLength)
                .IsRequired(false)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.Birthdate)
                .HasColumnName(nameof(EntityInformations.Birthdate))
                .HasColumnType(SqlColumnTypesConstants.Date)
                .IsRequired(false);

            builder.Property(a => a.CompanyName)
                .HasColumnName(nameof(EntityInformations.CompanyName))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(EntityInformationConfigurationConstants.CompanyNameMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired(false);

            builder.Property(a => a.IsActive)
                .HasColumnName(nameof(EntityInformations.IsActive))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(a => a.CreatedById)
                .HasColumnName(nameof(EntityInformations.CreatedById))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.CreatedDate)
                .HasColumnName(nameof(EntityInformations.CreatedDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2)
                .HasDefaultValueSql(SqlDefaultConstants.SqlDateTimeDefaultValue)
                .IsRequired();

            builder.Property(a => a.UpdatedById)
                .HasColumnName(nameof(EntityInformations.UpdatedById))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.UpdatedDate)
                .HasColumnName(nameof(EntityInformations.UpdatedDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2);

            builder.Property(a => a.RemovedById)
                .HasColumnName(nameof(EntityInformations.RemovedById))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.RemovedDate)
                .HasColumnName(nameof(EntityInformations.RemovedDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2);

            // Each Entity Information has only one Entity
            builder.HasOne(u => u.Entity)
                .WithOne(ui => ui.EntityInformation)
                .HasForeignKey<EntityInformations>(ui => ui.EntityId);

            // Each Entity Inforamation can have many EntityContacts
            builder.HasMany(a => a.EntityContacts)
                .WithOne(b => b.EntityInformations)
                .HasForeignKey(c => c.EntityInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Each Entity Information can have many EntityAddress
            builder.HasMany(a => a.EntityAddresses)
                .WithOne(b => b.EntityInformations)
                .HasForeignKey(c => c.EntityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

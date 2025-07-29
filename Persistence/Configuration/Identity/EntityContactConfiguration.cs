namespace Persistence.Configuration.Identity
{
    public class EntityContactConfiguration : IEntityTypeConfiguration<EntityContacts>
    {
        public void Configure(EntityTypeBuilder<EntityContacts> builder)
        {
            builder.ToTable(name: EntityContactConfigurationConstants.TableName);
            builder.HasKey(a => new { a.Id, a.EntityInformationId, a.ContactTypeCode });

            builder.Property(a => a.Id)
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier)
                .HasDefaultValueSql(SqlDefaultConstants.SqlGuidDefaultValue);

            builder.HasIndex(a => a.ContactTypeCode);

            builder.Property(a => a.ContactTypeCode)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .HasColumnName(nameof(EntityContacts.ContactTypeCode))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(LvConfigurationConstants.CodeMaxLength);

            builder.Property(a => a.Value)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .HasColumnName(nameof(EntityContacts.Value))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(LvConfigurationConstants.ValueMaxLength);

            builder.Property(a => a.Name)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .HasColumnName(nameof(EntityContacts.Name))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(LvConfigurationConstants.NameMaxLength);

            builder.Property(a => a.IsActive)
                .HasDefaultValue(SqlDefaultConstants.SqlBitDefaultValue);

            builder.Property(a => a.IsActive)
                .HasColumnName(nameof(EntityAddress.IsActive))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(a => a.CreatedById)
                .HasColumnName(nameof(EntityAddress.CreatedById))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.CreatedDate)
                .HasColumnName(nameof(EntityAddress.CreatedDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2)
                .HasDefaultValueSql(SqlDefaultConstants.SqlDateTimeDefaultValue)
                .IsRequired();

            builder.Property(a => a.UpdatedById)
                .HasColumnName(nameof(EntityAddress.UpdatedById))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.UpdatedDate)
                .HasColumnName(nameof(EntityAddress.UpdatedDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2);

            builder.Property(a => a.RemovedById)
                .HasColumnName(nameof(EntityAddress.RemovedById))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.RemovedDate)
                .HasColumnName(nameof(EntityAddress.RemovedDate))
                .HasColumnType(SqlColumnTypesConstants.DateTime2);

            builder.HasOne(e => e.ContactType)
                .WithMany()
                .HasForeignKey(a => a.ContactTypeCode)
                .HasPrincipalKey(a => a.Code)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

namespace Persistence.Configuration.Identity
{
    public class EntityAddressConfiguration : IEntityTypeConfiguration<EntityAddress>
    {
        public void Configure(EntityTypeBuilder<EntityAddress> builder)
        {
            builder.ToTable(name: EntityAddressConfigurationConstants.TableName);
            builder.HasKey(a => new { a.Id, a.EntityId, a.AddressId, a.AddressTypeCode });

            builder.Property(a => a.Id)
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier)
                .HasDefaultValueSql(SqlDefaultConstants.SqlGuidDefaultValue);

            builder.Property(a => a.EntityId)
                .HasColumnName(nameof(EntityAddress.EntityId))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

            builder.Property(a => a.AddressTypeCode)
                .HasColumnName(nameof(EntityAddress.AddressTypeCode))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(LvConfigurationConstants.CodeMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.AddressId)
                .HasColumnName(nameof(EntityAddress.AddressId))
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier);

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

            builder.HasOne(e => e.AddressType)
                .WithMany()
                .HasForeignKey(a => a.AddressTypeCode)
                .HasPrincipalKey(a => a.Code)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Address)
                .WithOne(x => x.UserAddresses)
                .HasForeignKey<EntityAddress>(a => a.AddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

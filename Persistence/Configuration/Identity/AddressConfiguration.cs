namespace Persistence.Configuration.Identity
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(name: AddressConfigurationConstants.TableName);
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnType(SqlColumnTypesConstants.UniqueIdentifier)
                .HasDefaultValueSql(SqlDefaultConstants.SqlGuidDefaultValue);

            builder.Property(a => a.StreetAddress1)
                .HasColumnName(nameof(Address.StreetAddress1))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.StreetAddress1MaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired();

            builder.Property(a => a.StreetAddress2)
                .HasColumnName(nameof(Address.StreetAddress2))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.StreetAddress2MaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.ZipCode)
                .HasColumnName(nameof(Address.ZipCode))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.ZipCodeMaxLength);

            builder.Property(a => a.PostalCode)
                .HasColumnName(nameof(Address.PostalCode))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.PostalCodeMaxLength);

            builder.Property(a => a.City)
                .HasColumnName(nameof(Address.City))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.CityMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.State)
                .HasColumnName(nameof(Address.State))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.StateMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.Province)
                .HasColumnName(nameof(Address.Province))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.ProvinceMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.County)
                .HasColumnName(nameof(Address.County))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.CountyMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue);

            builder.Property(a => a.CountryCode)
                .HasColumnName(nameof(Address.CountryCode))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(AddressConfigurationConstants.CountryCodeMaxLength)
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .IsRequired();

            builder.Property(a => a.Longitude)
                .HasColumnName(nameof(Address.Longitude))
                .HasColumnType(SqlColumnTypesConstants.Decimal108);

            builder.Property(a => a.Latitude)
                .HasColumnName(nameof(Address.Latitude))
                .HasColumnType(SqlColumnTypesConstants.Decimal108);

            builder.Property(a => a.IsActive)
                .HasColumnName(nameof(Address.IsActive))
                .HasColumnType(SqlColumnTypesConstants.Bit)
                .HasDefaultValue(SqlDefaultConstants.SqlBitDefaultValue);

            builder.Property(a => a.FullAddress)
                .HasColumnName(nameof(Address.FullAddress))
                .IsUnicode(SqlDefaultConstants.SqlUnicodeDefaultValue)
                .HasMaxLength(AddressConfigurationConstants.FullAddressMaxLength)
                .HasColumnType(SqlColumnTypesConstants.Varchar);
        }
    }
}

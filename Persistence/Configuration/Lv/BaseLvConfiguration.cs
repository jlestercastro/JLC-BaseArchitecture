namespace Persistence.Configuration.Lv
{
    public class BaseLvConfiguration<TLv, TKey> : IEntityTypeConfiguration<TLv>
        where TLv : BaseLv
        where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TLv> builder)
        {
            builder.HasKey(a => new { a.Id, a.Code });

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Code)
                .HasColumnName(nameof(BaseLv.Code))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(LvConfigurationConstants.CodeMaxLength)
                .IsRequired();

            builder.Property(a => a.Name)
                .HasColumnName(nameof(BaseLv.Name))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(LvConfigurationConstants.NameMaxLength)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasColumnName(nameof(BaseLv.Description))
                .HasColumnType(SqlColumnTypesConstants.Varchar)
                .HasMaxLength(LvConfigurationConstants.DescriptionMaxLength)
                .IsRequired(false);

            builder.Property(a => a.SortOrder)
                .HasColumnName(nameof(BaseLv.SortOrder))
                .HasColumnType(SqlColumnTypesConstants.SmallInt)
                .IsRequired();

            builder.Property(a => a.IsActive)
                .HasDefaultValue(true);

            builder.Property(a => a.EffectiveDate)
                .HasColumnName(nameof(BaseLv.EffectiveDate))
                .HasColumnType(SqlColumnTypesConstants.Date)
                .HasDefaultValue(new DateTime(2025, 01,01))
                .IsRequired(false);

            builder.Property(a => a.ExpirationDate)
                .HasColumnName(nameof(BaseLv.ExpirationDate))
                .HasColumnType(SqlColumnTypesConstants.Date)
                .HasDefaultValue(new DateTime(9999, 01, 01))
                .IsRequired(false);
        }
    }
}

namespace Persistence.Configuration.Lv
{
    public class LvAddressTypeConfiguration : BaseLvConfiguration<LvAddressType, long>
    {
        public override void Configure(EntityTypeBuilder<LvAddressType> builder)
        {
            base.Configure(builder);

            builder.AddSeedData();
        }
    }
}

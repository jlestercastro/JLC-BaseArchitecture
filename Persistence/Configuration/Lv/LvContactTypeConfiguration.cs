namespace Persistence.Configuration.Lv
{
    public class LvContactTypeConfiguration : BaseLvConfiguration<LvContactType, long>
    {
        public override void Configure(EntityTypeBuilder<LvContactType> builder)
        {
            base.Configure(builder);

            builder.AddSeedData();
        }
    }
}

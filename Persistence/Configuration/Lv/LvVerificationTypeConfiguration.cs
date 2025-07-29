namespace Persistence.Configuration.Lv
{
    public class LvVerificationTypeConfiguration : BaseLvConfiguration<LvVerificationType, long>
    {
        public override void Configure(EntityTypeBuilder<LvVerificationType> builder)
        {
            base.Configure(builder);

            builder.AddSeedData();
        }
    }
}

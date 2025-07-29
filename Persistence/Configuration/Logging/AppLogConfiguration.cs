namespace Persistence.Configuration.Logging
{
    public class AppLogConfiguration : IEntityTypeConfiguration<AppLog>
    {
        public void Configure(EntityTypeBuilder<AppLog> builder)
        {
            builder.ToTable(name: AppLogConfigurationConstants.TableName);
            builder.HasIndex(a => new
            {
                a.Timestamp,
                a.Level,
                a.Logger,
                a.UserId,
                a.CorrelationId
            });
        }
    }
}

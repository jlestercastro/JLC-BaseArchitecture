
namespace Persistence.Context
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : BaseDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

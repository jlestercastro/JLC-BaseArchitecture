namespace Persistence.Repositories
{
    public class BaseLvRepository<TEntity>(ApplicationDbContext context) : IBaseLvRepository<TEntity> where TEntity : BaseLv
    {
        protected readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public virtual async Task<TEntity?> GetAsync(long key)
        {
            return await _context.FindAsync<TEntity>(key);
        }

        public virtual async Task<TEntity?> GetAsync(long key, bool isTracked)
        {
            if (!isTracked)
                return await _context.Set<TEntity>().AsNoTracking().Where(a => a.Id.Equals(key)).FirstOrDefaultAsync();
            else
                return await _context.FindAsync<TEntity>(key);
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool isTracked)
        {
            if (!isTracked)
                return await _context.Set<TEntity>().AsNoTracking().Where(expression).FirstOrDefaultAsync();
            else
                return await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }
    }
}

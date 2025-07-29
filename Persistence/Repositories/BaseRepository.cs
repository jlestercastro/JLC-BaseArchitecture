namespace Persistence.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>(ApplicationDbContext context) : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public virtual async Task<TEntity?> GetAsync(TKey key)
        {
            return await _context.FindAsync<TEntity>(key);
        }

        public virtual async Task<TEntity?> GetAsync(TKey key, bool isTracked)
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

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AnyAsync(expression);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _context.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
            return entities;
        }

        public virtual void Update(TEntity entity) => _context.Update(entity);

        public virtual TEntity Remove(TEntity entity)
        {
            return (TEntity)_context.Remove((object)entity).Entity;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).CountAsync();
        }

        public void Detach(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}

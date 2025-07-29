using Domain.Primitives;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IBaseLvRepository<TEntity> where TEntity : BaseLv
    {
        Task<TEntity?> GetAsync(long key);
        Task<TEntity?> GetAsync(long key, bool isTracked);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool isTracked);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
    }
}

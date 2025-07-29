using Domain.Entities.Identity;

namespace Domain.Repositories.Identity
{
    public interface IEntityTokenRepository : IBaseRepository<EntityTokens, Guid>
    {
    }
}

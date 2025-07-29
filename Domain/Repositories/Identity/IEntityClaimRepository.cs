using Domain.Entities.Identity;

namespace Domain.Repositories.Identity
{
    public interface IEntityClaimRepository : IBaseRepository<EntityClaims, Guid>
    {
    }
}

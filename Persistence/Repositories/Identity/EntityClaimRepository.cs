namespace Persistence.Repositories.Identity
{
    public sealed class EntityClaimRepository(ApplicationDbContext context) :
        BaseRepository<EntityClaims, Guid>(context), IEntityClaimRepository
    {

    }
}

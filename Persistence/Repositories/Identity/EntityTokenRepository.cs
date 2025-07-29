namespace Persistence.Repositories.Identity
{
    public sealed class EntityTokenRepository(ApplicationDbContext context) :
        BaseRepository<EntityTokens, Guid>(context), IEntityTokenRepository
    {

    }
}

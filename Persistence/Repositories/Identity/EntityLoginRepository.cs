namespace Persistence.Repositories.Identity
{
    public sealed class EntityLoginRepository(ApplicationDbContext context) :
        BaseRepository<EntityLogin, Guid>(context), IEntityLoginRepository
    {

    }
}

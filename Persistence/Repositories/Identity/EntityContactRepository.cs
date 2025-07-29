namespace Persistence.Repositories.Identity
{
    public sealed class EntityContactRepository(ApplicationDbContext context) :
        BaseRepository<EntityContacts, Guid>(context), IEntityContactRepository
    {

    }
}

namespace Persistence.Repositories.Identity
{
    public sealed class EntityVerificationsRepository(ApplicationDbContext context) :
        BaseRepository<EntityVerifications, Guid>(context), IEntityVerificationsRepository
    {

    }
}

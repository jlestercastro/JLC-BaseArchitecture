namespace Persistence.Repositories.Identity
{
    public sealed class EntityInformationRepository(ApplicationDbContext context) :
        BaseRepository<EntityInformations, Guid>(context), IEntityInformationRepository
    {

    }
}

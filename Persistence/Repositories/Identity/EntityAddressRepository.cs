namespace Persistence.Repositories.Identity
{
    public sealed class EntityAddressRepository(ApplicationDbContext context) :
        BaseRepository<EntityAddress, Guid>(context), IEntityAddressRepository
    {

    }
}

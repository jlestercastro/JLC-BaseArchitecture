namespace Persistence.Repositories.Identity
{
    public sealed class AddressRepository(ApplicationDbContext context) :
        BaseRepository<Address, Guid>(context), IAddressRepository
    {

    }
}

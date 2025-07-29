
namespace Persistence.Repositories.Lv
{
    public sealed class LvAddressTypeRepository(ApplicationDbContext context) :
        BaseLvRepository<LvAddressType>(context), ILvAddressTypeRepository
    {

    }
}

using Domain.Repositories.Lv;

namespace Persistence.Repositories.Lv
{
    public sealed class LvContactTypeRepository(ApplicationDbContext context) :
        BaseLvRepository<LvContactType>(context), ILvContactTypeRepository
    { 

    }
}


namespace Persistence.Repositories.Lv
{
    public sealed class LvVerificationCodeTypeRepository(ApplicationDbContext context) :
        BaseLvRepository<LvVerificationType>(context), ILvVerificationCodeTypeRepository
    {

    }
}

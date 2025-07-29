namespace Persistence.Repositories.Identity
{
    public sealed class RolesRepository(ApplicationDbContext context) :
        BaseRepository<Roles, Guid>(context), IRolesRepository
    {

    }
}

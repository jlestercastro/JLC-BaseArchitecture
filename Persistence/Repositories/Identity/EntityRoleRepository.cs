namespace Persistence.Repositories.Identity
{
    public sealed class EntityRoleRepository(ApplicationDbContext context) :
        BaseRepository<EntityRoles, Guid>(context), IEntityRolesRepository
    {

    }
}

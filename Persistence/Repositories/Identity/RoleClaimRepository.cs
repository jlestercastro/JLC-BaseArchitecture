namespace Persistence.Repositories.Identity
{
    public sealed class RoleClaimRepository(ApplicationDbContext context) :
        BaseRepository<RoleClaims, Guid>(context), IRoleClaimsRepository
    {

    }
}

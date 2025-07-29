
namespace Persistence.Repositories.Identity
{
    public sealed class EntityRepository(ApplicationDbContext context) :
        BaseRepository<Entity, Guid>(context), IEntityRepository
    {
        public async Task<Entity?> GetUserWithVerificationsByIdAsync(Guid userId, string referenceId, string verificationTypeCode)
        {
            return await _context.Users
                .Include(a => a.EntityInformation)
                .AsSplitQuery()
                .Include(b => b.Claims)
                .AsSplitQuery()
                .Include(ur => ur.EntityRoles)
                .AsSplitQuery()
                .Include(a => 
                        a.EntityVerifications
                        .Where(a => 
                            !a.IsUsed &&
                            a.ReferenceId == referenceId &&
                            a.VerificationCodeType == verificationTypeCode)
                        .Take(1)
                )
                .AsSplitQuery()
                .FirstOrDefaultAsync(a => a.Id ==userId);
        }

        public async Task<Entity?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Email.Equals(email));
        }

        public async Task<Entity?> GetUserWithAuthenticationDetailsByEmailAsync(string email)
        {
            return await _context.Users
                .Include(a => a.EntityInformation)
                .AsSplitQuery()
                .Include(b => b.Claims)
                .AsSplitQuery()
                .Include(ur => ur.EntityRoles)
                .AsSplitQuery()
                .Include(ver => ver.EntityVerifications)
                .AsSplitQuery()
                .FirstOrDefaultAsync(a => a.Email.Equals(email));
        }
    }
}

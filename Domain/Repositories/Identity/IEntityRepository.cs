using Domain.Entities.Identity;

namespace Domain.Repositories.Identity
{
    public interface IEntityRepository : IBaseRepository<Entity, Guid>
    {
        Task<Entity?> GetUserWithVerificationsByIdAsync(Guid userId, string referenceId, string verificationTypeCode);
        Task<Entity?> GetUserByEmailAsync(string email);
        Task<Entity?> GetUserWithAuthenticationDetailsByEmailAsync(string email);
    }
}

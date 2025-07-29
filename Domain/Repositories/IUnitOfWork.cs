using Domain.Repositories.Identity;
using Domain.Repositories.Lv;

namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Identity Repositories

        IAddressRepository AddressRepository { get; }
        IRoleClaimsRepository RoleClaimsRepository { get; }
        IRolesRepository RolesRepository { get; }
        IEntityAddressRepository EntityAddressRepository { get; }
        IEntityClaimRepository EntityClaimRepository { get; }
        IEntityContactRepository EntityContactRepository { get; }
        IEntityInformationRepository EntityInformationRepository { get; }
        IEntityLoginRepository EntityLoginRepository { get; }   
        IEntityRepository EntityRepository { get; }
        IEntityRolesRepository EntityRolesRepository { get; }
        IEntityTokenRepository EntityTokenRepository { get; }
        IEntityVerificationsRepository VerificationCodesRepository { get; }

        #endregion

        #region Logging Repositories

        #endregion

        #region Lv Repositories
        ILvAddressTypeRepository LvAddressTypeRepository { get; }
        ILvContactTypeRepository LvContactTypeRepository { get; }
        ILvVerificationCodeTypeRepository LvVerificationCodeTypeRepository { get; }
        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

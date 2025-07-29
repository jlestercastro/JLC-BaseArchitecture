using Domain.Entities.Lv;
using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityAddress : BaseEntity<Guid>, IBaseAudit
    {
        public virtual Guid EntityId { get; set; }
        public string AddressTypeCode { get; set; } = default!;
        public Guid? AddressId { get; set; }

        public bool IsActive { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? RemovedById { get; set; }
        public DateTime? RemovedDate { get; set; }

        public virtual EntityInformations EntityInformations { get; set; } = default!;
        public virtual LvAddressType AddressType { get; set; } = default!;
        public virtual Address Address { get; set; } = default!;
    }
}

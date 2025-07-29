using Domain.Entities.Lv;
using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityContacts : BaseEntity<Guid>, IBaseAudit
    {
        public virtual Guid EntityInformationId { get; set; } = default!;
        public string ContactTypeCode { get; set; } = default!;
        public string? Value { get; set; }
        public string Name { get; set; } = default!;

        public bool IsActive { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? RemovedById { get; set; }
        public DateTime? RemovedDate { get; set; }

        public virtual EntityInformations EntityInformations { get; set; } = default!;
        public virtual LvContactType ContactType { get; set; } = default!;
    }
}

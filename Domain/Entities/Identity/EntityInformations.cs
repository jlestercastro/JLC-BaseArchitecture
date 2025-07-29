using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityInformations : BaseEntity<Guid>, IBaseAudit
    {
        public virtual Guid EntityId { get; set; } = default!;
        public bool IsIndividual { get; set; }
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Suffix { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public DateTime? Birthdate { get; set; }
        public string CompanyName { get; set; } = default!;

        public bool IsActive { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? RemovedById { get; set; }
        public DateTime? RemovedDate { get; set; }

        public virtual Entity Entity { get; set; } = default!;
        public virtual ICollection<EntityContacts> EntityContacts { get; set; } = default!;
        public virtual ICollection<EntityAddress> EntityAddresses { get; set; } = default!;
    }
}

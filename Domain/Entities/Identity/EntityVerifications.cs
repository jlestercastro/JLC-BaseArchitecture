using Domain.Entities.Lv;
using Domain.Primitives;

namespace Domain.Entities.Identity
{
    public class EntityVerifications : BaseEntity<Guid>
    {
        public string ReferenceId { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string VerificationCodeType { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; }
        public DateTime UsedDate { get; set; }
        public string IpAddress { get; set; } = default!;
        public string AdditionalData { get; set; } = default!;

        public short FailedAttempt { get; set; }

        public virtual Guid EntityId { get; set; }
        public virtual Entity Entity { get; set; } = default!;
        public virtual LvVerificationType LvVerificationCodeType {get;set; } = default!;
    }
}

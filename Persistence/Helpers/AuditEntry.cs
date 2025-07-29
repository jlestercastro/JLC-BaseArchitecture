using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Persistence.Helpers
{
    public class AuditEntry(EntityEntry entry)
    {
        public EntityEntry Entry { get; } = entry;
        public string TableName { get; set; } = default!;
        public string AuditType { get; set; } = default!;
        public string EntityId { get; set; } = default!;
        public string IpAddress { get; set; } = default!;
        public string RecordId { get; set; } = default!;
        public string HttpMethod { get; set; } = default!;
        public string Endpoint { get; set; } = default!;
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<string> ChangedColumns { get; } = new List<string>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditLog ToAudit()
        {
            var audit = new AuditLog
            {
                Timestamp = DateTime.UtcNow,
                EventType = AuditType,
                TableName = TableName,
                RecordId = string.Join(",", KeyValues.Select(kv => kv.Value)),
                UserId = EntityId,
                OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),
                ChangedColumns = string.Join(",", ChangedColumns),
                HttpMethod = HttpMethod,
                Endpoint = Endpoint
            };
            return audit;
        }
    }
}

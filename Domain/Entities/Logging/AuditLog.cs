namespace Domain.Entities.Logging
{
    public class AuditLog
    {
        public long Id { get; set; }

        // Basic information
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string EventType { get; set; } = default!;// "Create", "Update", "Delete", "Login", etc.
        public string TableName { get; set; } = default!; // Database table or entity name
        public string RecordId { get; set; } = default!; // ID of the affected record

        // User context
        public string UserId { get; set; } = default!; // ASP.NET Identity UserId

        // Request context
        public string HttpMethod { get; set; } = default!;
        public string Endpoint { get; set; } = default!;

        // Change details
        public string OldValues { get; set; } = default!; // JSON serialized previous state
        public string NewValues { get; set; } = default!; // JSON serialized new state
        public string ChangedColumns { get; set; } = default!; // Comma-separated list of changed columns
    }
}

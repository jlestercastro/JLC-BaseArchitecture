namespace Domain.Entities.Logging
{
    public class AppLog
    {
        public long Id { get; set; }

        // Timestamp
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Log level (Information, Warning, Error, Critical, Debug, Trace)
        public string Level { get; set; } = default!;

        // Log message
        public string Message { get; set; } = default!;

        // Exception details (if applicable)
        public string Exception { get; set; } = default!;

        // Source/logger name
        public string Logger { get; set; } = default!;

        // Additional properties for web requests
        public string HttpMethod { get; set; } = default!;
        public string Path { get; set; } = default!;
        public string IpAddress { get; set; } = default!;

        // User context
        public string UserId { get; set; } = default!;
        public string UserName { get; set; } = default!;

        // Performance metrics
        // For tracking request duration
        public long? DurationMs { get; set; } = default!; 

        // Correlation ID for tracing requests across services
        public string CorrelationId { get; set; } = default!;

        // Additional custom properties as JSON
        // Serialized JSON of additional data
        public string Properties { get; set; } = default!;
    }
}

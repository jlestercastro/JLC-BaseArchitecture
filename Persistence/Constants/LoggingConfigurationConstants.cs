namespace Persistence.Constants
{
    public class AppLogConfigurationConstants
    {
        public const string TableName = "AppLog";
    }
    public class AuditLogConfigurationConstants
    {
        public const string TableName = "AuditLog";
        public const int EventTypeMaxLength = 100;
        public const int TableNameMaxLength = 100;
        public const int RecordIdMaxLength = 100;
        public const int UserIdMaxLength = 100;
        public const int HttpMethodMaxLength = 50;
        public const int EndpointMaxLength = 200;
    }
}

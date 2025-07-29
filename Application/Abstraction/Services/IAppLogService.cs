using Microsoft.Extensions.Logging;

namespace Application.Abstraction.Services
{
    public interface IAppLogService
    {
        void Log(LogLevel level, string message, Exception exception = null, IDictionary<string, object> additionalData = null);
        void LogInformation(string message, IDictionary<string, object> additionalData = null);
        void LogWarning(string message, IDictionary<string, object> additionalData = null);
        void LogError(string message, Exception exception = null, IDictionary<string, object> additionalData = null);
        void LogDebug(string message, IDictionary<string, object> additionalData = null);
        void LogCritical(string message, Exception exception = null, IDictionary<string, object> additionalData = null);
        void LogTrace(string message, IDictionary<string, object> additionalData = null);

        // For structured logging
        void LogInformation(string template, params object[] args);
        void LogWarning(string template, params object[] args);
        void LogError(Exception exception, string template, params object[] args);
    }
}

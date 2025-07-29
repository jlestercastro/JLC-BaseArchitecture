using Application.Abstraction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    internal class AppLogService : IAppLogService
    {
        private readonly ILogger<AppLogService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppLogService(ILogger<AppLogService> logger, IHttpContextAccessor httpContextAccessor = null)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Log(LogLevel level, string message, Exception exception = null, IDictionary<string, object> additionalData = null)
        {
            using (_logger.BeginScope(GetLogScope(additionalData)))
            {
                _logger.Log(level, exception, message);
            }
        }

        public void LogInformation(string message, IDictionary<string, object> additionalData = null)
        {
            Log(LogLevel.Information, message, null, additionalData);
        }

        public void LogWarning(string message, IDictionary<string, object> additionalData = null)
        {
            Log(LogLevel.Warning, message, null, additionalData);
        }

        public void LogError(string message, Exception exception = null, IDictionary<string, object> additionalData = null)
        {
            Log(LogLevel.Error, message, exception, additionalData);
        }

        public void LogDebug(string message, IDictionary<string, object> additionalData = null)
        {
            Log(LogLevel.Debug, message, null, additionalData);
        }

        public void LogCritical(string message, Exception exception = null, IDictionary<string, object> additionalData = null)
        {
            Log(LogLevel.Critical, message, exception, additionalData);
        }

        public void LogTrace(string message, IDictionary<string, object> additionalData = null)
        {
            Log(LogLevel.Trace, message, null, additionalData);
        }

        // Structured logging methods
        public void LogInformation(string template, params object[] args)
        {
            _logger.LogInformation(template, args);
        }

        public void LogWarning(string template, params object[] args)
        {
            _logger.LogWarning(template, args);
        }

        public void LogError(Exception exception, string template, params object[] args)
        {
            _logger.LogError(exception, template, args);
        }

        private Dictionary<string, object> GetLogScope(IDictionary<string, object> additionalData)
        {
            var scope = new Dictionary<string, object>();

            // Add HTTP context information if available
            if (_httpContextAccessor?.HttpContext != null)
            {
                var httpContext = _httpContextAccessor.HttpContext;
                scope.Add("RequestId", httpContext.TraceIdentifier);
                scope.Add("RequestPath", httpContext.Request.Path);
                scope.Add("User", httpContext.User.Identity?.Name ?? "Anonymous");
            }

            // Add additional data if provided
            if (additionalData != null)
            {
                foreach (var item in additionalData)
                {
                    scope.Add(item.Key, item.Value);
                }
            }

            return scope;
        }
    }
}

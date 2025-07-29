using System.Net;

namespace Persistence.Context
{
    internal sealed class EntityContext(IHttpContextAccessor httpContextAccessor) : IEntityContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string EntityId =>
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        public string? UserEmail =>
             _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) ?? string.Empty;

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;


        public string IpAddress()
        {
            var ipString = GetClientIp();
            if (IPAddress.TryParse(ipString, out var ipAddress))
            {
                return ipString;
            }
            return null;
        }
            

        public string GetClientIp()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return null;

            // Check for forwarded headers (when behind proxy/load balancer)
            var forwardedHeader = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(forwardedHeader))
            {
                // The X-Forwarded-For header can contain multiple IPs (proxy chain)
                // The client IP is the first one in the list
                var ips = forwardedHeader.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(ip => ip.Trim());

                // If configured to trust only certain proxies, you might need to get the last untrusted IP
                return ips.FirstOrDefault();
            }

            // Fall back to the direct connection IP
            return httpContext.Connection.RemoteIpAddress?.ToString();
        }
    }
}

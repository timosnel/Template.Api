using Microsoft.AspNetCore.Builder;
using Name.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Extensions
    {
        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecurityHeadersMiddleware>();
            return app;
        }
    }
}

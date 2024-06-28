using cleanwave_platform.iam.Infrastructure.Pipeline.Components;

namespace cleanwave_platform.iam.Infrastructure.Pipeline.Extensions;

public static class RequestAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}
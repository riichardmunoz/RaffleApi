using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authentication;

namespace Raffle.Api.Base.Authentication
{
    [ExcludeFromCodeCoverage]
    public static class AuthMiddlewareSetupExtension
    {
        public static void AddApiKeyAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Authorization")
                .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("Authorization", options => { });
        }
    }
}

﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Raffle.Api.Base.HealthChecks
{
    [ExcludeFromCodeCoverage]
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddRaffleHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy(), tags: new List<string> { "ms" })
                .AddCheck("db-check", new DatabaseHealthCheck("ConnectionStrings:Base", configuration), tags: new List<string> { "db" });

            return services;
        }
    }
}

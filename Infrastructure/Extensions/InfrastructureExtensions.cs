using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raffle.Domain.IResources;
using Raffle.Domain.IService;
using Raffle.Domain.Ports;
using Raffle.Domain.Service;
using Raffle.Infrastructure.Addapters;
using Raffle.Infrastructure.EntityFramework;
using Raffle.Infrastructure.EntityFramework.Adapters;
using Raffle.Infrastructure.Resources;
using Raffle.Raffle.Domain.Ports;
using Raffle.Raffle.Infrastructure.Addapters;
using Serilog;

namespace Raffle.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue("Database:UseInMemory", false))
            {
                AddInMemoryDatabase(services, configuration);
            }
            else
            {
                AddSqlServer(services, configuration);
            }

            services.AddSingleton(Log.Logger);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAssignedNumberService, AssignedNumberService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<IResource, Resource>();
            services.AddSingleton<IMessagesProvider, MessagesProvider>();
            services.AddSingleton<IConfigProvider, ConfigProvider>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IQueryWrapper), typeof(DapperWrapper));
            services.AddTransient<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("Base")));

            return services;
        }

        private static void AddInMemoryDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersistenceContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
                options.ConfigureWarnings(warnings =>
                {
                    warnings.Default(WarningBehavior.Log);
                });
            });
        }

        private static void AddSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersistenceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Base"),
                    sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.MigrationsHistoryTable("__MicroMigrationHistoryRaffle", configuration.GetConnectionString("BaseSchema"));
                    });

                options.ConfigureWarnings(warnings =>
                {
                    warnings.Default(WarningBehavior.Log);
                });
            });
        }
    }
}

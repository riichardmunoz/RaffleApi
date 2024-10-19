using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Raffle.Infrastructure.EntityFramework;

namespace Raffle.Api
{
    [ExcludeFromCodeCoverage]
    public class PersistenceContextFactory : IDesignTimeDbContextFactory<PersistenceContext>
    {
        public PersistenceContext CreateDbContext(string[] args)
        {
            var Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PersistenceContext>();
            optionsBuilder.UseSqlServer(Config.GetConnectionString("Base")!, sqlopts =>
            {
                sqlopts.MigrationsHistoryTable("__MicroMigrationHistoryRaffle", Config.GetValue<string>("BaseSchema"));
            });

            return new PersistenceContext(optionsBuilder.Options, Config);
        }
    }
}

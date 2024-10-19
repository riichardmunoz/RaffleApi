using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raffle.Domain.Entities.Client;
using Raffle.Domain.Entities.Product;
using Raffle.Domain.Entities.User;
using Raffle.Infrastructure.EntityFramework;

namespace Raffle.Infrastructure.Extensions
{
    public class AutoMigrateDbRaffle : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoMigrateDbRaffle(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PersistenceContext>();

                if (!AllMigrationsApplied(context))
                {
                    context.Database.Migrate();
                }

                EnsureSeeded(context);
            }

            return Task.CompletedTask;
        }

        private bool AllMigrationsApplied(PersistenceContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        private void EnsureSeeded(PersistenceContext context)
        {
            if (!context.Set<ClientEntity>().Any())
            {
                context.Set<ClientEntity>().AddRange(new List<ClientEntity>
                {
                    new() {Id = new("79cb32a8-6384-42f4-bdae-d0e66adcdf14"), Name = "Bingos y Juegos Baltazar", Address = "Calle Luna Calle Sol" },
                    new() {Name = "Sorteos La Madrina", Address = null }
                });

                context.SaveChanges();
            }

            if (!context.Set<ProductEntity>().Any())
            {
                context.Set<ProductEntity>().AddRange(new List<ProductEntity>
                {
                    new() {Name = "Sorteo de un Carro Mazda 0 Km", Description = "Se sortea un hermoso Carro Mazda para este próximo 01 de Noviembre del 2024", ClientId = new("79cb32a8-6384-42f4-bdae-d0e66adcdf14") },
                    new() {Name = "Juego de 20 Millones de pesos", Description = "Para este próximo 15 de Noviembre se sortean 20 Millones de pesos", ClientId = new("79cb32a8-6384-42f4-bdae-d0e66adcdf14") },
                });

                context.SaveChanges();
            }

            if (!context.Set<UserEntity>().Any())
            {
                context.Set<UserEntity>().AddRange(new List<UserEntity>
                {
                    new() {FullName = "Juan Valderrama", Phone = "3184442255", Address = null },
                    new() {FullName = "Pedro Picapiedra", Phone = "3115558844", Address = "Despues de la esquina" },
                });

                context.SaveChanges();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

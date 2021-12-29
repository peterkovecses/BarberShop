using BarberShop.Data.Seed.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Data.BarberShopDbContext>();
                var migrations = dbContext.Database.GetMigrations().ToHashSet();
                if (dbContext.Database.GetAppliedMigrations().Any(a => !migrations.Contains(a)))
                    throw new InvalidOperationException("Az adatbázison már van olyan migráció futtatva, amit azóta töröltek a projektbõl. Töröld az adatbázist vagy javítsd a migrációk állapotát, majd indítsd újra az alkalmazást!");
                dbContext.Database.Migrate();

                // create the admin role
                var roleSeeder = scope.ServiceProvider.GetRequiredService<IRoleSeedService>();
                await roleSeeder.SeedRoleAsync();

                // create the admin user
                var userSeeder = scope.ServiceProvider.GetRequiredService<IUserSeedService>();
                await userSeeder.SeedUserAsync();

                // create appointments
                var appointmentSeeder = scope.ServiceProvider.GetRequiredService<IAppointmentSeedService>();
                await appointmentSeeder.SeedAppointmentAsync();

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Limits.MaxRequestBodySize = 50 * 1024 * 1024;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}

using BarberShop.Data.Entities;
using BarberShop.Data.Interceptors;
using BarberShop.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BarberShop.Data
{
    public class BarberShopDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public BarberShopDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            TestDataConfiguration.ConfigureSeedData(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.AddInterceptors(SimpleAuditInterceptor.Instance);
    }
}

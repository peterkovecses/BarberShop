using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BarberShop.Data.Entities
{
    public class AppUser : IEntityTypeConfiguration<AppUser>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(au => au.Name).HasMaxLength(100);
        }
    }
}

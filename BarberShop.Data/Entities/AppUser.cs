using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BarberShop.Data.Entities
{
    public class AppUser : UserBase<AppUser>
    {
        public ICollection<Appointment>? Appointments { get; set; }

        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(au => au.Name).HasMaxLength(100);
        }
    }
}

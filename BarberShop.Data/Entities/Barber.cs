
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BarberShop.Data.Entities
{
    public class Barber : UserBase<Barber>
    {
        public string? PublicDescription { get; set; }        
        public bool IsDeleted { get; set; } = false;

        public ICollection<Appointment> BarberAppointments { get; set; }

        public override void Configure(EntityTypeBuilder<Barber> builder)
        {
            builder.ToTable("Barbers");
            builder.Property(au => au.Name).HasMaxLength(100);
        }
    }
}

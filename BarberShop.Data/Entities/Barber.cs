
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BarberShop.Data.Entities
{
    public class Barber : EntityBase<Barber>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PublicDescription { get; set; }
        public string? PhotoPath { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Appointment> Appointments { get; set; }

        public override void Configure(EntityTypeBuilder<Barber> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;


namespace BarberShop.Data.Entities
{
    public class ServiceType : EntityBase<ServiceType>
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public override void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.Property(tt => tt.Name).HasMaxLength(50);
            builder.HasIndex(tt => tt.Name).IsUnique();
        }
    }
}

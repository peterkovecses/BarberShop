using BarberShop.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BarberShop.Data.Entities
{
    public class Appointment : EntityBase<Appointment>
    {
        public DateTime Date { get; set; }

        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int? ServiceTypeId { get; set; }
        public ServiceType? ServiceType { get; set; }
        public PurchaseStatus? PurchaseStatus { get; set; }

        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasIndex(a => new { a.Date, a.BarberId }).IsUnique();

            builder.HasOne(a => a.Barber).WithMany(b => b.BarberAppointments)
                .HasForeignKey(a => a.BarberId).HasPrincipalKey(b => b.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.AppUser).WithMany(au => au.Appointments)
                .HasForeignKey(a => a.AppUserId).HasPrincipalKey(au => au.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ServiceType).WithMany(st => st.Appointments)
                .HasForeignKey(a => a.ServiceTypeId).HasPrincipalKey(st => st.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

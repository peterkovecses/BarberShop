using BarberShop.Data.Entities;
using BarberShop.Data.Seed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Data.Seed.Services
{
    public class AppointmentSeedService : IAppointmentSeedService
    {
        public BarberShopDbContext DbContext { get; }
        public AppointmentSeedService(BarberShopDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task SeedAppointmentAsync()
        {
            if (!DbContext.Appointments.Any())
            {
                var date = DateTime.Now;
                var ts = new TimeSpan(08, 00, 0);
                date = date.Date + ts;

                var time = date;

                for (int i = 1; i <= 120; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        DbContext.Appointments.Add(new Appointment { Date = time, BarberId = j });
                    }

                    if (i % 20 != 0)
                        time = time.AddMinutes(30);
                    else
                    {
                        date = date.AddDays(1);
                        time = date;
                    }
                }

                await DbContext.SaveChangesAsync();
            }
        }
    }
}

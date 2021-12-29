using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Data.Seed.Interfaces
{
    public interface IAppointmentSeedService
    {
        Task SeedAppointmentAsync();
    }
}

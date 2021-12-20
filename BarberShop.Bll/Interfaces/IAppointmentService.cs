using BarberShop.Bll.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberShop.Bll.Interfaces
{
    public interface IAppointmentService
    {
        public Task<IList<AppointmentDTO>> GetFreeAppointmentsAsync();

        public Task<IList<AppointmentDTO>> GetBarbersReservedAppointmentsAsync(int id);

        public Task UpdateAppointmentAsync(AppointmentDTO appointmentDTO);

        public Task CancelAppointmentAsync(int id);

        public void DeleteAppointment(int id);
    }
}

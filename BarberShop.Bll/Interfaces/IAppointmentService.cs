using BarberShop.Bll.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberShop.Bll.Interfaces
{
    public interface IAppointmentService
    {
        public Task<IList<AppointmentDTO>> GetFreeAppointmentsAsync(int barberId, DateTime date);

        public Task<IList<AppointmentDTO>> GetBarbersReservedAppointmentsAsync(int id);

        public Task<(bool, string)> CreateAppointmentAsync(OpeningHoursDTO openingHoursDTO);

        public Task UpdateAppointmentAsync(AppointmentDTO appointmentDTO);

        public Task<bool> ReserveAppointmentAsync(AppointmentDTO appointmentDTO);

        public Task CancelAppointmentAsync(int id);

        public void DeleteAppointment(int id);
    }
}

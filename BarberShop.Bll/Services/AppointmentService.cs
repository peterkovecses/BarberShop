using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using BarberShop.Data;
using BarberShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarberShop.Bll.Services
{
    public class AppointmentService : IAppointmentService
    {
        public BarberShopDbContext DbContext { get; }
        public AppointmentService(BarberShopDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private Expression<Func<Appointment, AppointmentDTO>> AppointmentSelector = a => new AppointmentDTO
        {
            Id = a.Id,
            Date = a.Date,
            ServiceTypeId = a.ServiceTypeId,
            ServiceTypeName = a.ServiceType.Name,
            AppUserId = a.AppUserId,
            AppUserName = a.AppUser.Name,
            BarberId = a.BarberId,
            BarberName = a.Barber.Name,
            PurchaseStatus = a.PurchaseStatus
        };

        public async Task<IList<AppointmentDTO>> GetFreeAppointmentsAsync()
        {
            return (await DbContext.Appointments.Where(a => a.AppUserId == null && a.Date > DateTime.Now)
                .Select(AppointmentSelector)
                .ToListAsync())
                .OrderBy(a => a.Date)
                .ToList();
        }

        public async Task<IList<AppointmentDTO>> GetBarbersReservedAppointmentsAsync(int id)
        {
            return (await DbContext.Appointments.Where(a => a.BarberId == id && a.AppUserId != null && a.Date > DateTime.Now)
                .Select(AppointmentSelector)
                .ToListAsync())
                .OrderBy(a => a.Date)
                .ToList();
        }

        public async Task UpdateAppointmentAsync(AppointmentDTO appointmentDTO)
        {
            var appointment = await DbContext.Appointments.FindAsync(appointmentDTO.Id);
            var entry = DbContext.Entry(appointment);

            entry.CurrentValues.SetValues(appointmentDTO);

            await DbContext.SaveChangesAsync();
        }

        public async Task CancelAppointmentAsync(int id)
        {
            var appointment = await DbContext.Appointments.FindAsync(id);

            if (appointment != null)
            {
                appointment.AppUserId = null;
                appointment.AppUser = null;
                appointment.ServiceTypeId = null;
                appointment.ServiceType = null;
                appointment.PurchaseStatus = null;
            }

            DbContext.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            DbContext.Appointments.Remove(new Appointment { Id = id });
            DbContext.SaveChanges();
        }
    }
}

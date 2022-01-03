using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using BarberShop.Data;
using BarberShop.Data.Enums;
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
            FullDate = a.Date,
            ServiceTypeId = a.ServiceTypeId,
            ServiceTypeName = a.ServiceType.Name,
            AppUserId = a.AppUserId,
            AppUserName = a.AppUser.Name,
            BarberId = a.BarberId,
            BarberName = a.Barber.Name,
            PurchaseStatus = a.PurchaseStatus
        };

        public async Task<IList<AppointmentDTO>> GetFreeAppointmentsAsync(int barberId, DateTime date)
        {
            return (await DbContext.Appointments.Where(a => a.AppUserId == null && a.Date.Date == date.Date && a.BarberId == barberId 
                && a.Date > DateTime.Now)
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

        public async Task<(bool, string)> CreateAppointmentAsync(OpeningHoursDTO openingHoursDTO)
        {
            var isDateCollision = await IsDateCollision(openingHoursDTO.BarberIdentities, openingHoursDTO.Opening, openingHoursDTO.Closing);

            var errorType = string.Empty;

            if (isDateCollision)
            {
                errorType = "Hiba történt. A megadott nyitvatartás ütközik meglévő időponttal.";
                return (false, errorType);
            }            

            var length = (openingHoursDTO.Closing - openingHoursDTO.Opening).TotalMinutes;

            var numberOfAppointments = (int)length / 30;

            var time = openingHoursDTO.Opening;

            for (int i = 0; i < numberOfAppointments; i++)
            {
                for (int j = 0; j < openingHoursDTO.BarberIdentities.Count; j++)
                {
                    DbContext.Appointments.Add(new Appointment { Date = time, BarberId = openingHoursDTO.BarberIdentities[j] });
                }
                
                time = time.AddMinutes(30);
            }

            var success = await DbContext.SaveChangesAsync();

            if (success == 0)
                errorType = "Hiba történt. Nem sikerült a nyitva tartás rögzítése.";

            return (success > 0, errorType);
        }

        /// <summary>
        /// Checks that the specified opening hours do not conflict with an existing appointment
        /// </summary>
        /// <param name="barbers"></param>
        /// <param name="from"></param>
        /// <param name="till"></param>
        /// <returns></returns>
        public async Task<bool> IsDateCollision(List<int> barbers, DateTime from, DateTime till)
        {
            var appointments = await DbContext.Appointments.Where(a => barbers.Contains(a.BarberId) && a.Date >= from && a.Date <= till).ToListAsync();

            if (appointments.Any())
                return true;

            return false;
        }

        public async Task UpdateAppointmentAsync(AppointmentDTO appointmentDTO)
        {
            if (appointmentDTO.PurchaseStatus == null)
                appointmentDTO.PurchaseStatus = PurchaseStatus.Reserved;
            var appointment = await DbContext.Appointments.FindAsync(appointmentDTO.Id);
            var entry = DbContext.Entry(appointment);

            entry.CurrentValues.SetValues(appointmentDTO);

            await DbContext.SaveChangesAsync();
        }

        public async Task<bool> ReserveAppointmentAsync(AppointmentDTO appointmentDTO)
        {
            var appointment = await DbContext.Appointments.FindAsync(appointmentDTO.Id);

            appointment.BarberId = appointmentDTO.BarberId;
            appointment.ServiceTypeId = appointmentDTO.ServiceTypeId;
            appointment.AppUserId = appointmentDTO.AppUserId;
            appointment.PurchaseStatus = PurchaseStatus.Reserved;

            var success = await DbContext.SaveChangesAsync();

            return success > 0;
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

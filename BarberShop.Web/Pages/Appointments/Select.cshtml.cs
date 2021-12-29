using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using BarberShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarberShop.Web.Pages.Appointments
{
    public class SelectModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        public IAppointmentService AppointmentService { get; }

        public SelectModel(UserManager<AppUser> userManager, IAppointmentService appointmentService)
        {
            _userManager = userManager;
            AppointmentService = appointmentService;
        }

        [BindProperty]
        public AppointmentDTO Appointment { get; set; }
        public IList<AppointmentDTO> FreeAppointments { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task OnGet(int? barberId, int? serviceTypeId, DateTime? date)
        {
            Appointment = new AppointmentDTO
            {                
                BarberId = barberId.Value,
                ServiceTypeId = serviceTypeId,
            };

            if (barberId != null && serviceTypeId != null && date != null)
                FreeAppointments = await AppointmentService.GetFreeAppointmentsAsync(barberId.Value, date.Value);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var success = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            if (!success)
                return NotFound();

            Appointment.AppUserId = userId;

            var result = await AppointmentService.ReserveAppointmentAsync(Appointment);

            if (result)
                StatusMessage = "Sikeres idõpontfoglalás.";

            else
                StatusMessage = "Hiba történt. Nem sikerült az idõpontfoglalás.";

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BarberShop.Web.Pages.BarbersAppointments
{
    public class IndexModel : PageModel
    {
        public IAppUserService AppUserService { get; }
        public IAppointmentService AppointmentService { get; }
        public IndexModel(IAppUserService appUserService, IAppointmentService appointmentService)
        {
            AppUserService = appUserService;
            AppointmentService = appointmentService;
        }

        public IList<AppointmentDTO> Appointments { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var success = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id);

            if (!success)
                return NotFound();

            var barberId = await AppUserService.GetBarberIdByAppUserIdAsync(id);

            Appointments = await AppointmentService.GetBarbersReservedAppointmentsAsync(barberId);

            return Page();
        }
    }
}

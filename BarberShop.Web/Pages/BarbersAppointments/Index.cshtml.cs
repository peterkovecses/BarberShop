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
        public IAppointmentService AppointmentService { get; }
        public IndexModel(IAppointmentService appointmentService)
        {
            AppointmentService = appointmentService;
        }

        public IList<AppointmentDTO> Appointments { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var success = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var barberId);

            if (!success)
                return NotFound();

            Appointments = await AppointmentService.GetBarbersReservedAppointmentsAsync(barberId);

            return Page();
        }
    }
}

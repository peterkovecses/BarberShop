using System.Collections.Generic;
using System.Threading.Tasks;
using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarberShop.Web.Pages.Admin.Appointments
{
    public class CreateModel : PageModel
    {
        public IAppointmentService AppointmentService { get; }
        public IBarberService BarberService { get; }

        public CreateModel(IAppointmentService appointmentService, IBarberService barberService)
        {
            AppointmentService = appointmentService;
            BarberService = barberService;
        }

        [BindProperty]
        public OpeningHoursDTO OpeningHours { get; set; }

        public IList<BarberDTO> BarbersInDb { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string message)
        {
            if (message != null)
                StatusMessage = message;

            BarbersInDb = await BarberService.GetBarbersAsync();

            if (BarbersInDb == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return await GetBarbersAsync();

            var result = await AppointmentService.CreateAppointmentAsync(OpeningHours);

            if (result.Item1)
                StatusMessage = "Sikeres rögzítés.";

            else
                StatusMessage = result.Item2;

            return RedirectToPage(new { message = StatusMessage });
        }

        public async Task<ActionResult> GetBarbersAsync()
        {
            BarbersInDb = await BarberService.GetBarbersAsync();

            if (BarbersInDb == null)
                return NotFound();

            return Page();
        }
    }
}

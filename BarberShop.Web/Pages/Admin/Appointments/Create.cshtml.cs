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

        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return await GetBarbersAsync();
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

            await GetBarbersAsync();
            return Page();
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

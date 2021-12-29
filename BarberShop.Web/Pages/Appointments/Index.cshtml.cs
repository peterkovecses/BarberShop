using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.MyValidations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BarberShop.Web.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        public IAppointmentService AppointmentService { get; }
        public IBarberService BarberService { get; }
        public IServiceTypeService ServiceTypeService { get; }

        public IndexModel(IBarberService barberService, IServiceTypeService serviceTypeService)
        {
            BarberService = barberService;
            ServiceTypeService = serviceTypeService;
        }
        
        [BindProperty]
        [Required]
        [Display(Name = "Borbély")]
        public int BarberId { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Szolgáltatás")]
        public int ServiceTypeId { get; set; }

        [BindProperty]
        [MinDate(ErrorMessage = "Az dátum nem lehet kisebb a mai napnál.")]
        [Required]        
        public DateTime Date { get; set; } = DateTime.Today;

        public SelectList Barbers { get; set; }
        public SelectList ServiceTypes { get; set; }

        public async Task<ActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("/Appointments/ForLoggedInUsers");

            return await MakeSelectListsAsync();
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return await MakeSelectListsAsync();
            }

            return RedirectToPage("./Select", new { barberId = BarberId, serviceTypeId = ServiceTypeId , date = Date});
        }

        public async Task<ActionResult> MakeSelectListsAsync()
        {
            Barbers = new SelectList(await BarberService.GetBarbersAsync(), "Id", "Name");
            ServiceTypes = new SelectList(await ServiceTypeService.GetServiceTypesAsync(), "Id", "Name");

            if (Barbers == null || ServiceTypes == null)
                return NotFound();

            return Page();
        }
    }
}

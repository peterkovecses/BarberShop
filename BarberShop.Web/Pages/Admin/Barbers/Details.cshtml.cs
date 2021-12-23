using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarberShop.Web.Pages.Admin.Barbers
{
    public class DetailsModel : PageModel
    {
        public IAppUserService AppUserService { get; }

        public DetailsModel(IAppUserService appUserService)
        {
            AppUserService = appUserService;
        }

        public BarberUserDTO Barber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Barber = await AppUserService.GetBarberUserAsync(id.Value);

            if (Barber == null)
                return NotFound();

            return Page();
        }
    }
}

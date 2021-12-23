using System.Collections.Generic;
using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarberShop.Web.Pages.Admin.Barbers
{
    public class IndexModel : PageModel
    {
        public IBarberService BarberService { get; }
        public IndexModel(IBarberService barberService)
        {
            BarberService = barberService;
        }

        public IList<BarberDTO> Barbers { get; set; }

        public async Task OnGetAsync()
        {
            Barbers = await BarberService.GetBarbersAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await BarberService.DeleteBarberAsync(id);

            return new JsonResult(new { url = "reload" });
        }
    }
}

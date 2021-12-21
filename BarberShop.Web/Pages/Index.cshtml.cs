using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.DTOs;

namespace BarberShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IBarberService BarberService { get; }
        public IndexModel(IBarberService barberService)
        {
            BarberService = barberService;
        }

        public IEnumerable<BarberDTO> Barbers { get; set; }

        public async Task OnGetAsync()
        {
            var barbers = await BarberService.GetBarbersAsync();
            Barbers = barbers.OrderBy(d => d.Id).Take(4);
        }
    }
}

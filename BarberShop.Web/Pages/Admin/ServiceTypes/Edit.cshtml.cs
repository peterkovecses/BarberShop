using System.Threading.Tasks;
using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarberShop.Web.Pages.Admin.ServiceTypes
{
    public class EditModel : PageModel
    {
        public IServiceTypeService ServiceTypeService { get; }
        public EditModel(IServiceTypeService serviceTypeService)
        {
            ServiceTypeService = serviceTypeService;
        }

        [BindProperty]
        public ServiceTypeDTO ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            ServiceType = await ServiceTypeService.GetServiceTypeAsync(id.Value);

            if (ServiceType == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await ServiceTypeService.AddOrUpdateServiceTypeAsync(ServiceType);

            return RedirectToPage("./Index");
        }
    }
}

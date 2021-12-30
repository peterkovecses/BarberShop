using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarberShop.Web.Pages.Admin.ServiceTypes
{
    public class CreateModel : PageModel
    {
        public IServiceTypeService ServiceTypeService { get; }
        public CreateModel(IServiceTypeService serviceTypeService)
        {
            ServiceTypeService = serviceTypeService;
        }

        [BindProperty]
        public ServiceTypeDTO ServiceType { get; set; }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await ServiceTypeService.AddOrUpdateServiceTypeAsync(ServiceType);

            return RedirectToPage("./Index");
        }
    }
}

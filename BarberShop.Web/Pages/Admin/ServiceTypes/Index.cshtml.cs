using System.Collections.Generic;
using System.Threading.Tasks;
using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BarberShop.Web.Pages.Admin.ServiceTypes
{
    public class IndexModel : PageModel
    {
        public IServiceTypeService ServiceTypeService { get; }
        public IndexModel(IServiceTypeService serviceTypeService)
        {
            ServiceTypeService = serviceTypeService;
        }

        public IList<ServiceTypeDTO> ServiceTypes { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost(int id)
        {
            ServiceTypeService.DeleteServiceType(id);

            return new JsonResult(new { url = "reload" });
        }
    }
}

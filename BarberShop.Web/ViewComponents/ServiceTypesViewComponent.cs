using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using BarberShop.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Web.ViewComponents
{
    public class ServiceTypesViewComponent : ViewComponent
    {
        public IServiceTypeService ServiceTypeService { get; }
        public ServiceTypesViewComponent(IServiceTypeService serviceTypeService)
        {
            ServiceTypeService = serviceTypeService;
        }

        public class DisplayServiceTypes
        {
            public DisplayType DisplayType { get; set; }
            public IList<ServiceTypeDTO> ServiceTypes { get; set; }
        }

        public async Task<IViewComponentResult> InvokeAsync(DisplayType displayType)
        {
            var displayServiceType = new DisplayServiceTypes { DisplayType = displayType };

            displayServiceType.ServiceTypes = await ServiceTypeService.GetServiceTypesAsync();

            return View(displayServiceType);
        }
    }
}

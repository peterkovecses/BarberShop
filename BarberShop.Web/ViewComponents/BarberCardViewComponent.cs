using BarberShop.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Web.ViewComponents
{
    public class BarberCardViewComponent : ViewComponent
    {
        public IBarberService BarberService { get; }
        public BarberCardViewComponent(IBarberService barberService)
        {
            BarberService = barberService;
        }

        public class BarberCard
        {
            public int BarberId { get; set; }
            public string BarberName { get; set; }
            public string PhotoPath { get; set; }
            public string PublicDescription { get; set; }
        }

        public IViewComponentResult Invoke(int barberId, string barberName, string photoPath, string publicDescription)
        {
            var barberCard = new BarberCard
            {
                BarberId = barberId,
                BarberName = barberName,
                PhotoPath = photoPath,
                PublicDescription = publicDescription
            };

            return View(barberCard);
        }
    }
}

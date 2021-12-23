using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberShop.Web.Interfaces;
using BarberShop.Web.Enums;

namespace BarberShop.Web.Pages.Admin.Barbers
{
    public class CreateModel : PageModel
    {
        public IBarberService BarberService { get; }
        public IAppUserService AppUserService { get; }
        public IFileOperationService FileOperationService { get; }

        public CreateModel(IBarberService barberService, IAppUserService appUserService, IFileOperationService fileOperationService)
        {
            BarberService = barberService;
            AppUserService = appUserService;
            FileOperationService = fileOperationService;
        }

        [BindProperty]
        public BarberUserDTO Barber { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // File upload (photo)
            if (Barber.Photo != null && !string.IsNullOrEmpty(Barber.Photo.FileName))
            {
                var result = await FileOperationService.SaveFileAsync(Barber);

                if (result.Item2 == FileErrorType.NotAllowedExtension)
                {
                    ModelState.AddModelError("Barber.Photo", "A kép kiterjesztése nem megfelelõ.");
                    return Page();
                }

                if (result.Item2 == FileErrorType.Size)
                {
                    ModelState.AddModelError("Barber.Photo", "Maximális képméret: 5 MB.");
                    return Page();
                }

                Barber.PhotoPath = result.Item1;
            }

            // Save the barber to the database
            Barber.BarberId = await BarberService.AddBarberAsync(Barber);

            // Save the user
            await AppUserService.AddBarberUserAsync(Barber);

            return RedirectToPage("./Index");
        }
    }
}

using System.Threading.Tasks;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberShop.Web.Interfaces;
using BarberShop.Web.Enums;
using Ganss.XSS;

namespace BarberShop.Web.Pages.Admin.Barbers
{
    public class EditModel : PageModel
    {
        public IBarberService BarberService { get; }
        public IFileOperationService FileOperationService { get; }

        public EditModel(IBarberService barberService, IFileOperationService fileOperationService)
        {
            BarberService = barberService;
            FileOperationService = fileOperationService;
        }

        [BindProperty]
        public BarberDTO Barber { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Barber = await BarberService.GetBarberAsync(id.Value);

            if (Barber == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Barber.PublicDescription = new HtmlSanitizer().Sanitize(Barber.PublicDescription);

            // File upload (photo)
            if (Barber.Photo != null && !string.IsNullOrEmpty(Barber.Photo.FileName))
            {
                var result = await FileOperationService.SaveFileAsync(new BarberUserDTO { Name = Barber.Name, Photo = Barber.Photo });

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

            await BarberService.UpdateBarberAsync(Barber);

            return RedirectToPage("./Index");
        }
    }
}

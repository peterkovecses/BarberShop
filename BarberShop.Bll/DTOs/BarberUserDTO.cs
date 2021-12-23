
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Bll.DTOs
{
    public class BarberUserDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Név")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Leírás")]
        public string? PublicDescription { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefonszám")]
        public string PhoneNumber { get; set; }
       
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó megerősítés")]
        [Compare("Password", ErrorMessage = "Nem egyezik a beírt jelszó és a jelszó megerősítés.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Fotó")]
        public IFormFile? Photo { get; set; }

        public string? PhotoPath { get; set; }

        public int? BarberId { get; set; }
    }
}

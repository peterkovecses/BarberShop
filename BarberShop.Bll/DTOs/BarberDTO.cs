using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Bll.DTOs
{
    public class BarberDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Név")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Leírás")]
        public string? PublicDescription { get; set; }

        [Display(Name = "Leírás")]
        public string? ShortPublicDescription { get; set; }

        [Required]
        [Display(Name = "E-mail cím")]
        public string Email { get; set; }

        [Display(Name = "Fotó")]
        public IFormFile? Photo { get; set; }

        public string? PhotoPath { get; set; }
    }
}

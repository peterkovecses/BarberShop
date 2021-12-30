
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Bll.DTOs
{
    public class ServiceTypeDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Név")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Ár")]
        public double Price { get; set; }
    }
}

using BarberShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Bll.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        [Display(Name = "Időpont")]
        public DateTime Date { get; set; }

        [Display(Name = "Szolgáltatás")]
        public int? ServiceTypeId { get; set; }

        [Display(Name = "Szolgáltatás")]
        public string? ServiceTypeName { get; set; }

        [Display(Name = "Ügyfél")]
        public int? AppUserId { get; set; }

        [Display(Name = "Ügyfél")]
        public string? AppUserName { get; set; }

        [Display(Name = "Borbély")]
        public int BarberId { get; set; }

        [Display(Name = "Borbély")]
        public string BarberName { get; set; }

        [Display(Name = "Fizetés státusza")]
        public PurchaseStatus? PurchaseStatus { get; set; }
    }
}

using BarberShop.Bll.MyValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Bll.DTOs
{
    public class OpeningHoursDTO
    {
        [MinOpeningTime(ErrorMessage = "Az nyitás nem lehet kisebb mint a mostani idő.")]
        [Display(Name = "Nyitás")]
        public DateTime Opening { get; set; }

        [MinClosingTime(ErrorMessage = "A zárás nem lehet kisebb mint a nyitás ideje + 30 perc.")]
        [Display(Name = "Zárás")]
        public DateTime Closing { get; set; }

        [Required]
        [Display(Name = "Borbélyok")]
        public List<int> BarberIdentities { get; set; }
    }
}

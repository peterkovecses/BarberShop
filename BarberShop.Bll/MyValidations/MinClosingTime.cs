using System;
using System.ComponentModel.DataAnnotations;
using BarberShop.Bll.DTOs;

namespace BarberShop.Bll.MyValidations
{
    public class MinClosingTime : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var openingHours = (OpeningHoursDTO)validationContext.ObjectInstance;
                DateTime date = Convert.ToDateTime(value);

                if (date >= openingHours.Opening.AddMinutes(30))
                    return ValidationResult.Success;
                else
                    return new ValidationResult(ErrorMessage);
            }

            return new ValidationResult("A mező kitöltése kötelező.");
        }
    }
}

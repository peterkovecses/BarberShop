using System;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.Bll.MyValidations
{
    /// <summary>
    /// The selected day cannot be older than today
    /// </summary>
    public class MinDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime _dateStart = Convert.ToDateTime(value);
                if (_dateStart >= DateTime.Now.Date)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(ErrorMessage);
            }

            return new ValidationResult("A mező kitöltése kötelező.");
        }
    }
}

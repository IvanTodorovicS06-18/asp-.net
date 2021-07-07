using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rvas_ispit_projekat.Models
{
    public class RentalDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rental = (RentalBook)validationContext.ObjectInstance;
            if (rental.dateRented > DateTime.Now)
            {
                return new ValidationResult("the date you entered is in the future, please entere a valid date");
            }
            else return ValidationResult.Success;


        }
    }
}
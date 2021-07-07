using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rvas_ispit_projekat.Models
{
    public class BookPrice : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var book = (Book)validationContext.ObjectInstance;
            if (book.price <= 0)
            {
                return new ValidationResult("The price must be higher than 0");
            }
            else return ValidationResult.Success;


        }
    }
}
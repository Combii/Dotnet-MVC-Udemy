using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet_MVC_Vidly.Models
{
    public class StockMustBe1to20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            if (movie.NumberOfStock == null)
                return new ValidationResult("The Number in Stock field is required.");

            if (movie.NumberOfStock > 0 && movie.NumberOfStock <= 20 && movie.NumberOfStock != null)
                return ValidationResult.Success;
            
            return new ValidationResult("The field Number in Stock must be between 1 and 20");
        }
    }
}
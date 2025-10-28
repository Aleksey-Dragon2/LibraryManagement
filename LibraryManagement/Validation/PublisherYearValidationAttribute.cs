using System.ComponentModel.DataAnnotations;

namespace Presentation.Validation
{
    public class PublisherYearValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult("PublisherYear is required");

            if (value is not int year)
                return new ValidationResult("Invalid PublisherYear value");

            int currentYear = DateTime.Now.Year;
            if (year > currentYear)
                return new ValidationResult($"PublisherYear cannot be in the future (max {currentYear})");

            if (year < 0)               
                return new ValidationResult("PublisherYear cannot be negative");

            return ValidationResult.Success;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Presentation.Validation
{
    public class DateOfBirthValidationAttribute : ValidationAttribute
    {
        private readonly string _format = "yyyy-MM-dd";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult("DateOfBirth is required");

            if (value is not DateOnly date)
                return new ValidationResult("Invalid date value");

            if (date > DateOnly.FromDateTime(DateTime.Now))
                return new ValidationResult("DateOfBirth cannot be in the future");

            return ValidationResult.Success;
        }
    }
}

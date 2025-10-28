using Presentation.Validation;
using System.ComponentModel.DataAnnotations;

namespace Presentation.DTOs.Author.Request
{
    public record CreateAuthorRequestDto(
        [param: Required(ErrorMessage = "Name is required")]
        string Name,
        [param: Required(ErrorMessage = "DateOfBirth is required")]
        [param: DateOfBirthValidation]
        DateOnly DateOfBirth
    );
}

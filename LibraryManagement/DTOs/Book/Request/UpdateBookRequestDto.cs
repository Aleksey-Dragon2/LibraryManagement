using Presentation.Validation;
using System.ComponentModel.DataAnnotations;

namespace Presentation.DTOs.Book.Request
{
    public record UpdateBookRequestDto(
        [param: Required(ErrorMessage = "Title is required")]
        string Title,
        [param: Required(ErrorMessage = "PublisherYear is required")]
        [param:PublisherYearValidation]
        int PublisherYear,
        [param: Required(ErrorMessage = "AuthorId is required")]
        int AuthorId
    );
}

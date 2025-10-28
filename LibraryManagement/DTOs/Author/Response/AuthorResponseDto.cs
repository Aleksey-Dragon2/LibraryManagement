namespace Presentation.DTOs.Author.Response
{
    public record AuthorResponseDto(
        int Id,
        string Name,
        DateOnly DateOfBirth
    );
}

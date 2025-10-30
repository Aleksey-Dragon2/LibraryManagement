
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IQueryService
    {
        Task<IEnumerable<Author>> GetAllAuthorsWithCountBooksAsync(int countBooks);
        Task<IEnumerable<Author>> GetAllAuthorsStartWithAsync(string nameStart);
        Task<IEnumerable<Book>> GetAllBooksByAuthorSortedByYearAsync(int authorId);
        Task<IEnumerable<Book>> GetAllBookPublishedAfterYearAsync(int year);
    }
}


using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IQueryRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsWithCountBooksAsync(int countBooks);
        Task<IEnumerable<Author>> GetAllAuthorsStartWithAsync(string nameStart);
        Task<IEnumerable<Book>> GetAllBooksByAuthorSortedByYearAsync(int authorId);
        Task<IEnumerable<Book>> GetAllBookPublishedAfterYearAsync(int year);
    }
}

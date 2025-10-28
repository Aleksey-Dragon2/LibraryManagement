using Domain.Entities;

namespace Application.Abstractions
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(int id, Book book);
        Task<bool> DeleteAsync(int id);
    }
}

using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task<Author> UpdateAsync(int id, Author author);
        Task<bool> DeleteAsync(int id);
    }
}

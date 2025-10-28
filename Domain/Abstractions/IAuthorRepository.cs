using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetAsync();
        Task<Author> CreateAsync();
        Task<Author> UpdateAsync();
        Task<bool> DeleteAsync();
    }
}


using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetAsync(int id)
        {
            return await _authorRepository.GetAsync(id);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            return await _authorRepository.CreateAsync(author);
        }

        public async Task<Author> UpdateAsync(int id, Author author)
        {
            return await _authorRepository.UpdateAsync(id, author);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _authorRepository.DeleteAsync(id);
        }
    }
}

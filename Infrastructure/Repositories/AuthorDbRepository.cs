using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthorDbRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id== id);
            return author;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await _context.AddAsync(author);
            await  _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(int id, Author author)
        {
            author.Id = id;
             _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id== id);
            if (author == null)
                return false;
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

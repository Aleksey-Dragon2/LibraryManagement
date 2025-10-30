using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class QueryDbRepository : IQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public QueryDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAllAuthorsWithCountBooksAsync(int countBooks)
        {
            var authors = await _context.Authors
                .Where(a => a.Books.Count >= countBooks)
                .ToListAsync();
            return authors;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsStartWithAsync(string nameStart)
        {
            var authors = await _context.Authors
                .Where(a => a.Name.StartsWith(nameStart))
                .ToListAsync();
            return authors;
        }

        public async Task<IEnumerable<Book>> GetAllBooksByAuthorSortedByYearAsync(int authorId)
        {
            var books = await _context.Books
                .Where(b => b.AuthorId == authorId)
                .OrderBy(b => b.PublisherYear)
                .ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> GetAllBookPublishedAfterYearAsync(int year)
        {
            var books = await _context.Books
                .Where(b => b.PublisherYear >= year)
                .ToListAsync();
            return books;
        }
    }
}

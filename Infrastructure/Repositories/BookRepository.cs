using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.DB;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly ApplicationContext _context; 
        public BookRepository(ApplicationContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.FromResult(_context.Books.AsEnumerable());
        }
        public async Task<Book?> GetAsync(int id)
        {
            var book = _context.Books.FirstOrDefault(book => book.Id == id);
            return await Task.FromResult(book);
        }
        public async Task<Book> CreateAsync(Book book)
        {
            book.GetType().GetProperty("Id")?.SetValue(book, _context.Books.Count + 1);
            _context.Books.Add(book);
            return await Task.FromResult(book);
        }
        public async Task<Book> UpdateAsync(int id, Book book)
        {
            var existing = _context.Books.First(b => b.Id == id);
            existing.Title = book.Title;
            existing.AuthorId = book.AuthorId;
            existing.PublisherYear = book.PublisherYear;
            return await Task.FromResult(existing);
        }
        public Task<bool> DeleteAsync(int id)
        {
            var book = _context.Books.First(b => b.Id == id);
            _context.Books.Remove(book);
            return Task.FromResult(true);
        }
    }
}

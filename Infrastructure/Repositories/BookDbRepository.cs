
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookDbRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookDbRepository(ApplicationDbContext context) {
            _context = context; 
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b=> b.Id == id);
            return book;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            book.Id= id;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(a=> a.Id==id);
            if (book==null) return false;
            _context.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

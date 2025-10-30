using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        public BookService(IBookRepository bookRepository, IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _bookRepository.GetAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            var author = await _authorService.GetAsync(book.AuthorId);
            if (author == null)
                throw new AuthorNotFoundException(book.AuthorId);

            return await _bookRepository.CreateAsync(book);
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            var author = await _authorService.GetAsync(book.AuthorId);
            if (author == null)
                throw new AuthorNotFoundException(book.AuthorId);

            return await _bookRepository.UpdateAsync(id, book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
        }
    }
}

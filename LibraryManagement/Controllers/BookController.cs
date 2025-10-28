using Application.Abstractions;
using Application.Services;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.Book.Request;
using Presentation.DTOs.Book.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAllAsync()
        {
            var book = await _bookService.GetAllAsync();
            var response = book.Select(b => new BookResponseDto(
                b.Id,
                b.Title,
                b.PublisherYear,
                b.AuthorId));
            return Ok(response);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponseDto>> GetAsync(int id)
        {
            var book = await _bookService.GetAsync(id);
            if (book == null)
                return NotFound();

            var response = new BookResponseDto(
                book.Id,
                book.Title,
                book.PublisherYear,
                book.AuthorId);
            return Ok(response);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<BookResponseDto>> CreateAsync([FromBody]CreateBookRequestDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _bookService.CreateAsync(new Book
            {
                Title = dto.Title,
                PublisherYear = dto.PublisherYear,
                AuthorId = dto.AuthorId,
            });
            return Ok(response);

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BookResponseDto>> UpdateAsync(int id, [FromBody] UpdateBookRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingBook = await _bookService.GetAsync(id);
            if (existingBook == null)
                return NotFound();

            existingBook.Title = dto.Title;
            existingBook.PublisherYear = dto.PublisherYear;
            existingBook.AuthorId = dto.AuthorId;

            await _bookService.UpdateAsync(id, existingBook);

            var response = new BookResponseDto(
                existingBook.Id,
                existingBook.Title,
                existingBook.PublisherYear,
                existingBook.AuthorId);
            return Ok(response);
        }


        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var existingBook = await _bookService.GetAsync(id);
            if (existingBook == null)
                return NotFound();

            var response = await _bookService.DeleteAsync(id);

            return Ok(response);
        }
    }
}

using Application.Abstractions;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.Author.Response;
using Presentation.DTOs.Book.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService _queryService;
        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }
        // GET: api/<QueryController>
        [HttpGet("authors/with-min-books/{countBooks}")]
        public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAllAuthorsWithCountBooksAsync(int countBooks)
        {
            var authors = await _queryService.GetAllAuthorsWithCountBooksAsync(countBooks);

            var response = authors.Select(a => new AuthorResponseDto(
                a.Id,
                a.Name,
                a.DateOfBirth
            ));

            return Ok(response);
        }

        [HttpGet("authors/start-with/{nameStart}")]
        public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAllAuthorsStartWithAsync(string nameStart)
        {
            var authors = await _queryService.GetAllAuthorsStartWithAsync(nameStart);

            var response = authors.Select(a => new AuthorResponseDto(
                a.Id,
                a.Name,
                a.DateOfBirth
            ));

            return Ok(response);
        }
        [HttpGet("authors/by-author/{authorId}")]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAllBooksByAuthorSortedByYearAsync(int authorId)
        {
            var books = await _queryService.GetAllBooksByAuthorSortedByYearAsync(authorId);

            var response = books.Select(b => new BookResponseDto(
                b.Id,
                b.Title,
                b.PublisherYear,
                b.AuthorId
            ));

            return Ok(response);
        }

        [HttpGet("authors/published-after/{year}")]
        public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAllBookPublishedAfterYearAsync(int year)
        {
            var books = await _queryService.GetAllBookPublishedAfterYearAsync(year);

            var response = books.Select(b => new BookResponseDto(
                b.Id,
                b.Title,
                b.PublisherYear,
                b.AuthorId
            ));

            return Ok(response);
        }

    }
}

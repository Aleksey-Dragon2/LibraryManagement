using Application.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.Author.Request;
using Presentation.DTOs.Author.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorResponseDto>>> GetAllAsync()
        {
            var authors = await _authorService.GetAllAsync();

            var response = authors.Select(a => new AuthorResponseDto(
                a.Id,
                a.Name,
                a.DateOfBirth
            ));

            return Ok(response);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponseDto>> GetAsync(int id)
        {
            var author = await _authorService.GetAsync(id);
            if (author == null)
                return NotFound();

            var response = new AuthorResponseDto(
                author.Id,
                author.Name,
                author.DateOfBirth
            );

            return Ok(response);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult<AuthorResponseDto>> CreateAsync([FromBody] CreateAuthorRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newAuthor = new Author
            {
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth
            };

            var created = await _authorService.CreateAsync(newAuthor);

            var response = new AuthorResponseDto(
                created.Id,
                created.Name,
                created.DateOfBirth
            );

            return Ok(response);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorResponseDto>> UpdateAsync(int id, [FromBody] UpdateAuthorRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _authorService.GetAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.DateOfBirth = dto.DateOfBirth;

            await _authorService.UpdateAsync(id, existing);

            var response = new AuthorResponseDto(
                existing.Id,
                existing.Name,
                existing.DateOfBirth
            );

            return Ok(response);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var existing = await _authorService.GetAsync(id);
            if (existing == null)
                return NotFound();

            var result = await _authorService.DeleteAsync(id);

            return Ok(result);
        }
    }
}

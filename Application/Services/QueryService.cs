
using Application.Abstractions;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services
{
    public class QueryService : IQueryService
    {
        private readonly IQueryRepository _queryRepository;
        public QueryService(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsWithCountBooksAsync(int countBooks)
        {
            return await _queryRepository.GetAllAuthorsWithCountBooksAsync(countBooks);
        }
        public async Task<IEnumerable<Author>> GetAllAuthorsStartWithAsync(string nameStart)
        {
            return await _queryRepository.GetAllAuthorsStartWithAsync(nameStart);
        }
        public async Task<IEnumerable<Book>> GetAllBooksByAuthorSortedByYearAsync(int authorId)
        {
            return await _queryRepository.GetAllBooksByAuthorSortedByYearAsync(authorId);
        }
        public async Task<IEnumerable<Book>> GetAllBookPublishedAfterYearAsync(int year)
        {
            return await _queryRepository.GetAllBookPublishedAfterYearAsync(year);
        }


    }
}

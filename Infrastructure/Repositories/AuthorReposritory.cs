using Domain.Entities;
using Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthorReposritory
    {
        private readonly ApplicationContext _context;

        public AuthorReposritory(ApplicationContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            return Task.FromResult(_context.Authors.AsEnumerable());
        }

        public Task<Author?> GetAsync(int id)
        {
            var author = _context.Authors.FirstOrDefault(au => au.Id == id);
            return Task.FromResult(author);
        }

        public Task<Author> CreateAsync(Author author)
        {
            author.GetType().GetProperty("Id")?.SetValue(author, _context.Authors.Count + 1);
            _context.Authors.Add(author);
            return Task.FromResult(author);
        }

        public Task<Author> UpdateAsync(int id, Author author)
        {
            var existing = _context.Authors.First(au => au.Id == id);
            existing.Name = author.Name;
            existing.DateOfBirth = author.DateOfBirth;
            return Task.FromResult(existing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var author = _context.Authors.First(au => au.Id == id);
            _context.Authors.Remove(author);
            return Task.FromResult(true);
        }
    }
}

using Domain.Entities;
using Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book>  Books { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedAuthorsAndBooks();
        }

    }
}

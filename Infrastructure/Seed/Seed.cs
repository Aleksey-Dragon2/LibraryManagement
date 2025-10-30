using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Seed
{
    public static class Seed
    {
        public static void SeedAuthorsAndBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Leo Tolstoy", DateOfBirth = new DateOnly(1828, 9, 9) },
                new Author { Id = 2, Name = "Fyodor Dostoevsky", DateOfBirth = new DateOnly(1821, 11, 11) },
                new Author { Id = 3, Name = "Anton Chekhov", DateOfBirth = new DateOnly(1860, 1, 29) },
                new Author { Id = 4, Name = "Alexander Pushkin", DateOfBirth = new DateOnly(1799, 6, 6) }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "War and Peace", PublisherYear = 1869, AuthorId = 1 },
                new Book { Id = 2, Title = "Anna Karenina", PublisherYear = 1877, AuthorId = 1 },
                new Book { Id = 3, Title = "Resurrection", PublisherYear = 1899, AuthorId = 1 },
                new Book { Id = 4, Title = "The Brothers Karamazov", PublisherYear = 1880, AuthorId = 2 },
                new Book { Id = 5, Title = "Crime and Punishment", PublisherYear = 1866, AuthorId = 2 },
                new Book { Id = 6, Title = "The Idiot", PublisherYear = 1869, AuthorId = 2 },
                new Book { Id = 7, Title = "Notes from Underground", PublisherYear = 1864, AuthorId = 2 },
                new Book { Id = 8, Title = "The Cherry Orchard", PublisherYear = 1904, AuthorId = 3 },
                new Book { Id = 9, Title = "Uncle Vanya", PublisherYear = 1899, AuthorId = 3 },
                new Book { Id = 10, Title = "Three Sisters", PublisherYear = 1901, AuthorId = 3 },
                new Book { Id = 11, Title = "The Seagull", PublisherYear = 1896, AuthorId = 3 },
                new Book { Id = 12, Title = "Eugene Onegin", PublisherYear = 1833, AuthorId = 4 },
                new Book { Id = 13, Title = "Boris Godunov", PublisherYear = 1825, AuthorId = 4 },
                new Book { Id = 14, Title = "The Captain's Daughter", PublisherYear = 1836, AuthorId = 4 },
                new Book { Id = 15, Title = "Ruslan and Ludmila", PublisherYear = 1820, AuthorId = 4 }
            );
        }
    }
}

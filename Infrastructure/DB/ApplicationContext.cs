using Domain.Entities;

namespace Infrastructure.DB
{
    public class ApplicationContext
    {
        public List<Author> Authors { get; set; }

        public List<Book> Books { get; set; }

        public ApplicationContext()
        {
            Authors = new List<Author>();
            Books = new List<Book>();
        }
    }
}

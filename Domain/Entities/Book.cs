namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly PublisherYear { get; set; }
        public int AuthorId { get; set; }
    }
}

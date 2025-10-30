
public class AuthorNotFoundException : Exception
{
    public AuthorNotFoundException(int authorId)
        : base($"Автор с Id {authorId} не найден.")
    {
    }
}

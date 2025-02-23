namespace Library.Application.Domain.Books.Queries.GetBookDetails;

public record AuthorInformDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }
}

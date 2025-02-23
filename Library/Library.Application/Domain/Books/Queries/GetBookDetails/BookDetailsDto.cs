namespace Library.Application.Domain.Books.Queries.GetBookDetails;
public record BookDetailsDto
{
    public Guid Id { get; init; }

    public string Title { get; init; }

    public string Description { get; init; }

    public List<AuthorInformDto> Authors { get; init; }
}

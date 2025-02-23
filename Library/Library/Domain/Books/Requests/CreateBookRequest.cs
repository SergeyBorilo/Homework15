namespace Library.Api.Domain.Books.Requests;

public record CreateBookRequest(Guid Id, string Title, string Description);

namespace Library.Api.Domain.Authors.Requests;

public record UpdateAuthorRequest(string FirstName, string LastName, string? MiddleName = default);

using Library.Core.Common;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Validators;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Authors.Models;

public class Author : Entity, IAggregateRoot
{
    private readonly List<BookAuthor> _booksAuthors = [];

    private Author()
    {
    }

    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string? MiddleName { get; private set; }

    public IReadOnlyCollection<BookAuthor> BooksAuthors => _booksAuthors.AsReadOnly();

    public static Author Create(CreateAuthorData data)
    {
        Validate(new CreateAuthorValidator(), data);

        return new Author
        {
            Id = Guid.NewGuid(),
            FirstName = data.FirstName,
            LastName = data.LastName,
            MiddleName = data.MiddleName
        };
    }

    public void Update(UpdateAuthorData data)
    {
        Validate(new UpdateAuthorValidator(), data);

        FirstName = data.FirstName;
        LastName = data.LastName;
        MiddleName = data.MiddleName;
    }
}


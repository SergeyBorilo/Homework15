using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Validators;

namespace Library.Core.Domain.Books.Models;

public class Book : Entity, IAggregateRoot
{
    private readonly List<BookAuthor> _booksAuthors = new ();

    private Book()
    {
    }

    internal Book(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<BookAuthor> BooksAuthors => _booksAuthors.AsReadOnly();

    public static Book Create(CreateBookData data)
    {
        Validate<CreateBookData>(new CreateBookValidator(), data);

        return new Book(
            Guid.NewGuid(),
            data.Title,
            data.Description);
    }

    public void Update(UpdateBookData data)
    {
        Validate<UpdateBookData>(new UpdateBookValidator(), data);
        Title = data.Title;
        Description = data.Description;
    }
}

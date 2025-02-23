using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Validators;

namespace Library.Core.Domain.Books.Models;

public class BookAuthor : Entity
{
    private BookAuthor()
    {
    }

    internal BookAuthor(Guid bookId, Guid authorId)
    {
        BookId = bookId;
        AuthorId = authorId;
    }

    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }

    public static async Task<BookAuthor> Create(
        IAuthorMustExistChecker authorMustExistChecker,
        IBookMustExistChecker bookMustExistChecker,
        CreateBookAuthorData data)
    {
        await ValidateAsync(new CreateBookAuthorValidator(authorMustExistChecker, bookMustExistChecker), data);

        return new BookAuthor(data.BookId, data.AuthorId);
    }

}

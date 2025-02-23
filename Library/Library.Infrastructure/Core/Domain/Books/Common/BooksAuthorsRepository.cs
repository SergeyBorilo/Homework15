using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Models;
using Library.Persistence.LibrariesDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Books.Common;
internal class BooksAuthorsRepository(LibraryDbContext libraryDbContext) : IBooksAuthorsRepository
{
    public void Add(BookAuthor bookAuthor)
    {
        libraryDbContext.BookAuthors.Add(bookAuthor);
    }

    public async Task<BookAuthor> FindBookAuthorAsync(Guid bockId, Guid authorId, CancellationToken cancellationToken)
    {
        return await libraryDbContext.BookAuthors.SingleOrDefaultAsync(x => x.BookId == bockId && x.AuthorId == authorId, cancellationToken);
    }

    public void Delete(BookAuthor bookAuthor)
    {
       libraryDbContext.BookAuthors.Remove(bookAuthor);
    }
}

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
public class BookRepository(LibraryDbContext libraryDbContext) : IBooksRepository
{
    public async Task<Book> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await libraryDbContext
            .Books.Include(x => x.BooksAuthors)
            .ThenInclude(x => x.Author)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Book>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await libraryDbContext.Books.Where(b => ids.Contains(b.Id)).ToArrayAsync(cancellationToken);
    }

    public void Add(Book book)
    {
        libraryDbContext.Add(book);
    }

    public void Delete(IReadOnlyCollection<Book> bocks)
    {
        libraryDbContext.RemoveRange(bocks);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using Library.Persistence.LibrariesDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Authors.Common;

internal class AuthorsEfCoreRepository(LibraryDbContext libraryDbContext) : IAuthorsRepository
{
    public async Task<Author?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var author = await libraryDbContext
            .Authors
            .Include(a => a.BooksAuthors)
            .ThenInclude(ba => ba.Book)
            .SingleOrDefaultAsync(a => true, cancellationToken);
        return author;
    }

    public Task<IReadOnlyCollection<Author>> FindManyAsync(Guid ids, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<Author>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await libraryDbContext.Authors.Where(a => ids.Contains(a.Id)).ToArrayAsync(cancellationToken);
    }

    public void AddAuthor(Author author)
    {
        libraryDbContext.Authors.Add(author);
    }

    public void DeleteAuthor(IReadOnlyCollection<Author> authors)
    {
       libraryDbContext.Authors.RemoveRange(authors);
    }
}

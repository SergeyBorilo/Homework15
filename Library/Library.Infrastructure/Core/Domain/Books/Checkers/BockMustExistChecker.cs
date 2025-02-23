using Library.Core.Domain.Books.Checkers;
using Library.Persistence.LibrariesDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Books.Checkers;

public class BockMustExistChecker(LibraryDbContext libraryDbContext) : IBookMustExistChecker
{
    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await libraryDbContext.Books.AnyAsync(b => b.Id == id, cancellationToken);
    }
}

using Library.Core.Domain.Books.Checkers;
using Library.Persistence.LibrariesDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Books.Checkers;

public class AuthorMustExistChecker(LibraryDbContext libraryDbContext) : IAuthorMustExistChecker
{
    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await libraryDbContext.Authors.AnyAsync(a => a.Id == id, cancellationToken);
    }
}

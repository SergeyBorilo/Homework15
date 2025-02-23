using Library.Application.Domain.Books.Queries.GetBookDetails;
using Library.Persistence.LibrariesDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Books.Queris.GetBooksDetails;
public class GetBookDetailsQueryHandler(LibraryDbContext libraryDbContext) : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
{
    public async Task<BookDetailsDto> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        return await libraryDbContext
            .Books
            .AsNoTracking()
            .Include(x => x.BooksAuthors)
            .ThenInclude(x => x.Author)
            .Where(x => x.Id == request.Id)
            .Select(x => new BookDetailsDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Authors = x.BooksAuthors.Select(ba => new AuthorInformDto()
                {
                    Id = ba.Author.Id,
                    Name = ba.Author.MiddleName == null
                        ? $"{ba.Author.FirstName} {ba.Author.LastName}"
                        : $"{ba.Author.FirstName} {ba.Author.MiddleName} {ba.Author.LastName}"
                }).ToList()
            }).SingleAsync(cancellationToken);
    }
}


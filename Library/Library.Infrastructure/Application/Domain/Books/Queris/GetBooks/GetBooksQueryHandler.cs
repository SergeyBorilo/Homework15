using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Common;
using Library.Application.Domain.Books.Queries.GetBooks;
using Library.Persistence.LibrariesDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Books.Queris.GetBooks;
public class GetBooksQueryHandler(LibraryDbContext libraryDbContext) : IRequestHandler<GetBooksQuery, PageResponse<BookDto[]>>
{
    public async Task<PageResponse<BookDto[]>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = libraryDbContext.Books.AsNoTracking();
        var skip = (request.Page - 1) * request.PageSize;

        var books = await sqlQuery.Skip(skip).Take(request.PageSize).Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description
        }).ToArrayAsync(cancellationToken);

        var totalCount = await sqlQuery.CountAsync(cancellationToken);

        return new PageResponse<BookDto[]>(totalCount, books);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Common;
using Library.Application.Domain.Authors.Queries.GetAuthorsDetails;
using Library.Core.Domain.Authors.Models;
using Library.Persistence.LibrariesDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Authors.Queris.GetAuthors;
public class GetAuthorsQueryHandler(LibraryDbContext libraryDbContext) : IRequestHandler<GetAuthorsQuery, PageResponse<AuthorDto[]>>
{
    public async Task<PageResponse<AuthorDto[]>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = libraryDbContext.Authors.AsNoTracking();

        var skipCount = (request.Page - 1) * request.PageSize;

        var authors = await sqlQuery.Skip(skipCount).Take(request.PageSize).Select(a => new AuthorDto
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            MiddleName = a.MiddleName
        }).ToArrayAsync(cancellationToken);

        var totalCount = sqlQuery.CountAsync(cancellationToken);
        return new PageResponse<AuthorDto[]>(await totalCount, authors);
    }
}

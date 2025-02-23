using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using Library.Persistence.LibrariesDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Authors.Queris.GetAuthorsDetails;
internal class GetAuthorDetailsQueryHandler(LibraryDbContext libraryDbContext) : IRequestHandler<GetAuthorDetailsQuery, AuthorDetailsDto>
{
    public async Task<AuthorDetailsDto?> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
    {
        return await libraryDbContext
            .Authors
            .AsNoTracking()
            .Include(a => a.BooksAuthors)
            .ThenInclude(ba => ba.Book)
            .Select(a => new AuthorDetailsDto
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            MiddleName = a.MiddleName,
            Books = a.BooksAuthors.Select(ba => new BookDto()
            {
                Id = ba.Book.Id,
                Title = ba.Book.Title,
                Description = ba.Book.Description,
            }).ToList()
        }).FirstOrDefaultAsync(cancellationToken);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Domain.Authors.Queries.GetAuthors;
public record AuthorDetailsDto
{
    public Guid Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string? MiddleName { get; init; }

    public List<BookDto> Books { get; init; }

}

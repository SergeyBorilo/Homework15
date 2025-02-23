using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Domain.Authors.Queries.GetAuthors;
public record BookDto
{
    public Guid Id { get; init; }

    public string Title { get; init; }

    public string Description { get; init; }
}

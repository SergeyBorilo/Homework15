using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Books.Models;
using MediatR;

namespace Library.Application.Domain.Books.Queries.GetBooksByName;

public record GetBooksByNameQuery()
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}

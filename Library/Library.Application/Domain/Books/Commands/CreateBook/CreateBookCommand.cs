using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Domain.Books.Commands.CreateBook;
public record CreateBookCommand(string Title, string Description) : IRequest<Guid>;

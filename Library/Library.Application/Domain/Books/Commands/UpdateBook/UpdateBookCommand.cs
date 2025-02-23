using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Domain.Books.Commands.UpdateBook;
public record UpdateBookCommand(Guid Id, string Title, string Description) : IRequest;

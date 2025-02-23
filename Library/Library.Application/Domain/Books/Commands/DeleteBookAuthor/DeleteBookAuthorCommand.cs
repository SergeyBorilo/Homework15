using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Domain.Books.Commands.DeleteBookAuthor;
public record DeleteBookAuthorCommand(Guid BookId, Guid AuthorId) : IRequest;

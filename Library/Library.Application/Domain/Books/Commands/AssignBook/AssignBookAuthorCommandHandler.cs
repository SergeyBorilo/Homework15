using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Models;
using MediatR;

namespace Library.Application.Domain.Books.Commands.AssignBook;
public class AssignBookAuthorCommandHandler(
    IAuthorMustExistChecker authorMustExistChecker,
    IBookMustExistChecker bookMustExistChecker,
    IBooksAuthorsRepository bookAuthorRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<AssignBookAuthorCommand>
{
    public async Task Handle(AssignBookAuthorCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateBookAuthorData(command.BookId, command.AuthorId);
        var bookAuthor = await BookAuthor.Create(
            authorMustExistChecker,
            bookMustExistChecker,
            data);
        bookAuthorRepository.Add(bookAuthor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.DeleteBookAuthor;
internal class DeleteBookAuthorCommandHandler(
    IBooksAuthorsRepository bookAuthorRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookAuthorCommand>
{
    public async Task Handle(DeleteBookAuthorCommand command, CancellationToken cancellationToken)
    {
        var bookAuthor = await bookAuthorRepository.FindBookAuthorAsync(command.BookId, command.AuthorId, cancellationToken);
        bookAuthorRepository.Delete(bookAuthor);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

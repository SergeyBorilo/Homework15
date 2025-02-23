using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands.DeleteBook;
public class DeleteBookCommandHandler(
    IBooksRepository booksRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var book = await booksRepository.FindAsync(command.Id, cancellationToken);
        booksRepository.Delete(new[] { book });
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

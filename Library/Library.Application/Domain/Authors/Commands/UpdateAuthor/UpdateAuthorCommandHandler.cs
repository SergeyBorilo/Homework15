using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Models;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.UpdateAuthor;
public class UpdateAuthorCommandHandler(IAuthorsRepository authorsRepository,
    IUnitOfWork unintOfWork) : IRequestHandler<UpdateAuthorCommand>
{
    public async Task Handle(UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = await authorsRepository.FindAsync(command.Id, cancellationToken);

        var data = new UpdateAuthorData(command.FirstName, command.LastName, command.MiddleName);

        author.Update(data);

        await unintOfWork.SaveChangesAsync(cancellationToken);
    }
}

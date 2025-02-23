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

namespace Library.Application.Domain.Authors.Commands.CreateAuthor;

public record CreateAuthorCommandHandler(
    IAuthorsRepository AuthorsRepository,
    IUnitOfWork UnitOfWork) : IRequestHandler<CreateAuthorCommand, Guid>
{
    public async Task<Guid> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var data = new CreateAuthorData(command.FirstName, command.LastName, command.MiddleName);

        var author = Author.Create(data);
        AuthorsRepository.AddAuthor(author);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return author.Id;

    }

}

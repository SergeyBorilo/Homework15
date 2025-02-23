using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Authors.Common;

public interface IAuthorsRepository
{
    public Task<Author> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Author>> FindManyAsync(Guid ids, CancellationToken cancellationToken);

    public void AddAuthor(Author author);

    public void DeleteAuthor(IReadOnlyCollection<Author> authors);
}

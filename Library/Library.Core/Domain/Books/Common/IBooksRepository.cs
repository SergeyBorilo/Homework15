using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Common;
public interface IBooksRepository
{
    public Task<Book> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Book>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(Book book);

    public void Delete(IReadOnlyCollection<Book> bocks);
}

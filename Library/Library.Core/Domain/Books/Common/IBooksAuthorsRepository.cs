using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Common;
public interface IBooksAuthorsRepository
{
    public void Add(BookAuthor bookAuthor);

    public Task<BookAuthor> FindBookAuthorAsync(Guid bockId, Guid authorId, CancellationToken cancellationToken);

    public void Delete(BookAuthor bookAuthor);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Domain.Books.Data;
public record CreateBookAuthorData(Guid BookId, Guid AuthorId);

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Persistence.LibrariesDb;

namespace Library.Infrastructure.Core.Common;
internal class UnitOfWork(LibraryDbContext libraryDbContext) : IUnitOfWork
{

public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
{

    return await libraryDbContext.SaveChangesAsync(cancellationToken);
}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Domain.Books.Checkers;
public interface IAuthorMustExistChecker
{
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}

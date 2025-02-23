using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Domain.Authors.Data;
public record CreateAuthorData(
    string FirstName,
    string LastName,
    string? MiddleName = default);


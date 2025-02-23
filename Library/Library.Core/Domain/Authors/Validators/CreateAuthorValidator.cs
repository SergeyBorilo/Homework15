using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Library.Core.Domain.Authors.Data;

namespace Library.Core.Domain.Authors.Validators;
internal class CreateAuthorValidator : AbstractValidator<CreateAuthorData>
{
    public CreateAuthorValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x=>x.MiddleName).MaximumLength(100);
    }
}

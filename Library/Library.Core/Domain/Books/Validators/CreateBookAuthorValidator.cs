using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Data;

namespace Library.Core.Domain.Books.Validators;

public class CreateBookAuthorValidator(
    IAuthorMustExistChecker authorMustExistChecker,
    IBookMustExistChecker bookMustExistChecker)
{
    public async Task<ValidationResult> ValidateAsync<T>(T data, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

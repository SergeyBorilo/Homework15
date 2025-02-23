using System.Reflection;
using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Checkers;
using Library.Core.Domain.Books.Common;
using Library.Infrastructure.Core.Common;
using Library.Infrastructure.Core.Domain.Authors.Common;
using Library.Infrastructure.Core.Domain.Books.Checkers;
using Library.Infrastructure.Core.Domain.Books.Common;
using Library.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class InfrastructureRegistration
{    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // checkers
        services.AddScoped<IAuthorMustExistChecker, AuthorMustExistChecker>();
        services.AddScoped<IBookMustExistChecker, BockMustExistChecker>();

        // repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthorsRepository, AuthorsEfCoreRepository>();
        services.AddScoped<IBooksRepository, BookRepository>();
        services.AddScoped<IBooksAuthorsRepository, BooksAuthorsRepository>();

        // exceptions
        services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
        services.AddSingleton<IExceptionToResponseDeveloperMapper, ExceptionToResponseDeveloperMapper>();
        services.AddTransient<ExceptionHandlerDeveloperMiddleware>();
        services.AddTransient<ExceptionHandlerMiddleware>();

    }
}

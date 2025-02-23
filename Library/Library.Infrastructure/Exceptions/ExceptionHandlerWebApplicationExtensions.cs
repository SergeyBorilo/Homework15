using Microsoft.AspNetCore.Builder;

namespace Library.Infrastructure.Exceptions;

public static class ExceptionHandlerWebApplicationExtensions
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
            app.UseMiddleware<ExceptionHandlerDeveloperMiddleware>();
        else
            app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}

public interface IWebHostEnvironment
{
    bool IsDevelopment();
}

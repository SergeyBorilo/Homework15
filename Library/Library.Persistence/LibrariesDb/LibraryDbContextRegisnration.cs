using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence.LibrariesDb;
public static class LibraryDbContextRegisnration
{
    public static void RegisterlibrarysDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LibraryDb");

        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        LibraryDbContext.LibraryMigrationsHistoryTable,
                        LibraryDbContext.LibraryDbSchema);
                });
        });
    }
}

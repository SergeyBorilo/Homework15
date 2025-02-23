using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;
using Library.Persistence.LibrariesDb.EntityTypesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.LibrariesDb;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public static readonly string LibraryDbSchema = "library";
    public static readonly string LibraryMigrationsHistoryTable = "__LibraryDbMigrationsHistory";
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(LibraryDbSchema);
        modelBuilder.ApplyConfiguration(new AuthorEntityTypesConfigurations());
        modelBuilder.ApplyConfiguration(new BookEntityTypesConfigurations());
        modelBuilder.ApplyConfiguration(new AuthorsBooksEntityTypesConfigurations());
    }

}

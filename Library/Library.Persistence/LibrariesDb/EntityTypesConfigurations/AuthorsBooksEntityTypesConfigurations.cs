using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.LibrariesDb.EntityTypesConfigurations;
internal class AuthorsBooksEntityTypesConfigurations : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(ba => new { ba.BookId, ba.AuthorId });

        builder.HasOne(ba => ba.Book)
            .WithMany(b => b.BooksAuthors)
            .HasForeignKey(ba => ba.BookId);

        builder.HasOne(ba => ba.Author)
            .WithMany(a => a.BooksAuthors)
            .HasForeignKey(ba => ba.AuthorId);
    }
}

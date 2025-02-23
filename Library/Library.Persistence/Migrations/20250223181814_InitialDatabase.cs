using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Persistence.Migrations;

/// <inheritdoc />
public partial class InitialDatabase : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "library");

        migrationBuilder.CreateTable(
            name: "Authors",
            schema: "library",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Authors", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Books",
            schema: "library",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Books", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "BookAuthors",
            schema: "library",
            columns: table => new
            {
                BookId = table.Column<Guid>(type: "uuid", nullable: false),
                AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                table.ForeignKey(
                    name: "FK_BookAuthors_Authors_AuthorId",
                    column: x => x.AuthorId,
                    principalSchema: "library",
                    principalTable: "Authors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_BookAuthors_Books_BookId",
                    column: x => x.BookId,
                    principalSchema: "library",
                    principalTable: "Books",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_BookAuthors_AuthorId",
            schema: "library",
            table: "BookAuthors",
            column: "AuthorId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BookAuthors",
            schema: "library");

        migrationBuilder.DropTable(
            name: "Authors",
            schema: "library");

        migrationBuilder.DropTable(
            name: "Books",
            schema: "library");
    }
}

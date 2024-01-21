using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Tags = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Author", "Comment", "Content", "Date", "Tags" },
                values: new object[,]
                {
                    { 1, "Author1", "Comment1", "Content1", new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sport" },
                    { 2, "Author2", "Comment2", "Content2", new DateTime(2001, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sport" },
                    { 3, "Author3", "Comment3", "Content3", new DateTime(2002, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech" },
                    { 4, "Author4", "Comment4", "Content4", new DateTime(2002, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Health" },
                    { 5, "Author5", "Comment5", "Content5", new DateTime(2013, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "New" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}

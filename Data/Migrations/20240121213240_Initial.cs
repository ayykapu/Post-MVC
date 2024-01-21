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
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Regon = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

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
                    Tags = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street", "Nip", "Regon", "Title" },
                values: new object[,]
                {
                    { 1, "Kraków", "31-150", "małopolskie", "Św. Filipa 17", "83492384", "13424234", "WSEI" },
                    { 2, "Kraków", "31-150", "małopolskie", "Krowoderska 45/6", "2498534", "0873439249", "Firma" }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Author", "Comment", "Content", "Date", "OrganizationId", "Tags" },
                values: new object[,]
                {
                    { 1, "Author1", "Comment1", "Content1", new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sport" },
                    { 2, "Author2", "Comment2", "Content2", new DateTime(2001, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_OrganizationId",
                table: "posts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}

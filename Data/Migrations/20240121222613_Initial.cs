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
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Members_NumberOfMembers = table.Column<int>(type: "INTEGER", nullable: true),
                    Members_HighestRankMember = table.Column<string>(type: "TEXT", nullable: true),
                    Members_CountryMostMembers = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
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
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreateDate", "Description", "Name", "Members_CountryMostMembers", "Members_HighestRankMember", "Members_NumberOfMembers" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wyższa Szkoła Ekonomii i Informatyki w Krakowie", "WSEI", "Polska", "Member1", 30 },
                    { 2, new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akademia Górniczo-Hutnicza w Krakowie", "AGH", "USA", "Member145/6", 50 }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Author", "Comment", "Content", "Date", "GroupId", "Tags" },
                values: new object[,]
                {
                    { 1, "Author1", "Comment1", "Content1", new DateTime(2000, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sport" },
                    { 2, "Author2", "Comment2", "Content2", new DateTime(2001, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_GroupId",
                table: "posts",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}

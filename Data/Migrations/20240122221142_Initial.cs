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
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TagTitle = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostContent = table.Column<string>(type: "TEXT", nullable: false),
                    PostAuthor = table.Column<string>(type: "TEXT", nullable: false),
                    PostDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentAuthor = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    CommentContent = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagTitle" },
                values: new object[,]
                {
                    { 1, "Polityka" },
                    { 2, "Sport" },
                    { 3, "Nauka" },
                    { 4, "Motoryzacja" },
                    { 5, "Gry" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "PostAuthor", "PostContent", "PostDate", "TagId" },
                values: new object[,]
                {
                    { 1, "Janek", "W 2025 wybory na prezydenta!", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(3998), 1 },
                    { 2, "Grzegorz", "Real Madryt odpadł z ligi mistrzów.", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(4001), 2 },
                    { 3, "Ania", "Wiatr słoneczny zniekształcił atmosfere marsa!", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(4003), 3 },
                    { 4, "Kasia", "Toyota Supra vs Nissan Skyline R34?", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(4004), 4 },
                    { 5, "Alex", "Nie mogę się doczekać premiery GTA VI!", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(4034), 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentAuthor", "CommentContent", "CommentDate", "PostId" },
                values: new object[,]
                {
                    { 1, "Karolina", "Już nie mogę się doczekać!", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(3917), 1 },
                    { 2, "Milena", "Słabo im szło w tym sezonie.", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(3967), 2 },
                    { 3, "Andrzej", "Tak, doszło do trzykrotnego zwiększenia jej wielkości.", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(3969), 3 },
                    { 4, "Karol", "Oczywiście, że Toyota!", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(3971), 4 },
                    { 5, "Sam", "Najgorsze jest to, że na premierę na PC poczekamy pewnie do 2027.", new DateTime(2024, 1, 22, 23, 11, 41, 919, DateTimeKind.Local).AddTicks(3972), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TagId",
                table: "Posts",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}

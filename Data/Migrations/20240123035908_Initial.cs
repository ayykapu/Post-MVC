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
                    { 1, "Rozrywka" },
                    { 2, "Nauka" },
                    { 3, "Polityka" },
                    { 4, "Zdrowie" },
                    { 5, "Sport" },
                    { 6, "Technologia" },
                    { 7, "Rozwój" },
                    { 8, "Odkrycia" },
                    { 9, "Podróże" },
                    { 10, "Innowacje" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "PostAuthor", "PostContent", "PostDate", "TagId" },
                values: new object[,]
                {
                    { 1, "Janek", "Lorem Lorem", new DateTime(2024, 1, 23, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9271), 1 },
                    { 2, "Grzegorz", "Kocham jak nie działa mi w projekcie identity.", new DateTime(2024, 1, 23, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9274), 2 },
                    { 3, "Ania", "ZZZZZ", new DateTime(2024, 1, 23, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9276), 3 },
                    { 4, "Kasia", "Tragiczna dziś podoga!", new DateTime(2024, 1, 23, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9277), 4 },
                    { 5, "Alex", "Kocham Kraków.", new DateTime(2024, 1, 23, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9279), 5 },
                    { 6, "Michał", "Nowe odkrycia archeologiczne na Bliskim Wschodzie.", new DateTime(2024, 1, 22, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9280), 1 },
                    { 7, "Karolina", "Najnowsze trendy w świecie mody.", new DateTime(2024, 1, 21, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9282), 2 },
                    { 8, "Piotrek", "Odkryto nowe gatunki roślin w dżungli Amazonii.", new DateTime(2024, 1, 20, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9283), 3 },
                    { 9, "Magda", "Porównanie aparatów fotograficznych: Canon vs Nikon.", new DateTime(2024, 1, 19, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9285), 4 },
                    { 10, "Bartek", "Przyszłość sztucznej inteligencji.", new DateTime(2024, 1, 18, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9286), 5 },
                    { 11, "Monika", "Rekordy Guinnessa w sporcie.", new DateTime(2024, 1, 17, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9288), 1 },
                    { 12, "Tomasz", "Historia rozwoju technologii komputerowej.", new DateTime(2024, 1, 16, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9289), 2 },
                    { 13, "Ola", "Badania nad życiem pozaziemskim.", new DateTime(2024, 1, 15, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9291), 3 },
                    { 14, "Łukasz", "Nowości na rynku samochodowym.", new DateTime(2024, 1, 14, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9292), 4 },
                    { 15, "Natalia", "Kulinarne podróże po świecie.", new DateTime(2024, 1, 13, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9294), 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentAuthor", "CommentContent", "CommentDate", "PostId" },
                values: new object[,]
                {
                    { 1, "Użytkownik1", "Świetny post!", new DateTime(2024, 1, 21, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9186), 1 },
                    { 2, "Użytkownik2", "Ciekawe spostrzeżenia!", new DateTime(2024, 1, 22, 4, 59, 7, 846, DateTimeKind.Local).AddTicks(9234), 1 },
                    { 3, "Użytkownik3", "Mam pytanie...", new DateTime(2024, 1, 22, 22, 59, 7, 846, DateTimeKind.Local).AddTicks(9236), 2 },
                    { 4, "Użytkownik4", "Dobrze napisane!", new DateTime(2024, 1, 23, 4, 29, 7, 846, DateTimeKind.Local).AddTicks(9238), 3 },
                    { 5, "Użytkownik5", "Zgadzam się całkowicie!", new DateTime(2024, 1, 23, 4, 58, 57, 846, DateTimeKind.Local).AddTicks(9241), 3 }
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

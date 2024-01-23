using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Intital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostContent = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PostAuthor = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e4ac12f-0d75-4471-a0e3-3e5058771d13", "3e4ac12f-0d75-4471-a0e3-3e5058771d13", "mod", "MOD" },
                    { "794dd682-e4b9-4415-b033-c0762ff2a6d8", "794dd682-e4b9-4415-b033-c0762ff2a6d8", "user", "USER" },
                    { "eeb6b469-99ee-4478-86be-345da096ba70", "eeb6b469-99ee-4478-86be-345da096ba70", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02115dc0-ebbe-4d42-94ab-9ad4711f388d", 0, "2c3b1813-a194-4cfe-b3d7-87dd09d7ca10", "arkadiuszpol@onet.pl", true, false, null, "ARKADIUSZPOL@ONET.PL", "ARKADIUSZ", "AQAAAAIAAYagAAAAEBaZm2pVV3AfcyB1UeNcjkQgwMef9XyjJb+AvewH3PA+za1LBGyUZEtDgzd7BC2Jmg==", null, false, "c54927c2-bfe8-4f80-aaf1-407bda92dec8", false, "Arkadiusz" },
                    { "9211d460-777d-4534-8a47-664e4647a4c6", 0, "caa7f1ee-11fd-4262-bc0d-02673b82e4a7", "tomasz@o2.pl", true, false, null, "TOMASZ@o2.PL", "TOMASZ", "AQAAAAIAAYagAAAAEMTGS+zDvH6yS+Tt0ULEQFoLZntmC9QZ6qcnZhPuHU5JHbzrjj6oay9jKTAHK+B7gw==", null, false, "91db10ac-b617-404e-b093-eb07f18699b5", false, "Tomasz" },
                    { "c6061091-4aae-4a7b-ac89-0b7503698bc4", 0, "6d9396b9-2a7d-4b39-a273-f46b5bcab3d2", "tadek123@gmail.pl", true, false, null, "TADEK123@GMAIL.PL", "TADEK", "AQAAAAIAAYagAAAAEBDgcrC0UdpzQPKsld6AMJ7eZP8eqA1Y0HfN4dP/9qarf1y4wGYMstlpWcfbN6n5BA==", null, false, "06756371-29a9-4fed-a0ee-72ffcfd87097", false, "Tadek" }
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "794dd682-e4b9-4415-b033-c0762ff2a6d8", "02115dc0-ebbe-4d42-94ab-9ad4711f388d" },
                    { "3e4ac12f-0d75-4471-a0e3-3e5058771d13", "9211d460-777d-4534-8a47-664e4647a4c6" },
                    { "eeb6b469-99ee-4478-86be-345da096ba70", "c6061091-4aae-4a7b-ac89-0b7503698bc4" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "PostAuthor", "PostContent", "PostDate", "TagId" },
                values: new object[,]
                {
                    { 1, "Janek", "Lorem Lorem", new DateTime(2024, 1, 30, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1352), 1 },
                    { 2, "Grzegorz", "Kocham jak w końcu działa mi w projekcie identity.", new DateTime(2024, 1, 30, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1361), 2 },
                    { 3, "Ania", "ZZZZZ", new DateTime(2024, 1, 30, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1362), 3 },
                    { 4, "Kasia", "Tragiczna dziś podoga!", new DateTime(2024, 1, 30, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1372), 4 },
                    { 5, "Alex", "Kocham Kraków.", new DateTime(2024, 1, 30, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1374), 5 },
                    { 6, "Michał", "Nowe odkrycia archeologiczne na Bliskim Wschodzie.", new DateTime(2024, 1, 29, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1378), 1 },
                    { 7, "Karolina", "Najnowsze trendy w świecie mody.", new DateTime(2024, 1, 28, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1380), 2 },
                    { 8, "Piotrek", "Odkryto nowe gatunki roślin w dżungli Amazonii.", new DateTime(2024, 1, 27, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1381), 3 },
                    { 9, "Magda", "Porównanie aparatów fotograficznych: Canon vs Nikon.", new DateTime(2024, 1, 26, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1383), 4 },
                    { 10, "Bartek", "Przyszłość sztucznej inteligencji.", new DateTime(2024, 1, 25, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1385), 5 },
                    { 11, "Monika", "Rekordy Guinnessa w sporcie.", new DateTime(2024, 1, 24, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1406), 1 },
                    { 12, "Tomasz", "Historia rozwoju technologii komputerowej.", new DateTime(2024, 1, 23, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1408), 2 },
                    { 13, "Ola", "Badania nad życiem pozaziemskim.", new DateTime(2024, 1, 22, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1410), 3 },
                    { 14, "Łukasz", "Nowości na rynku samochodowym.", new DateTime(2024, 1, 21, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1414), 4 },
                    { 15, "Natalia", "Kulinarne podróże po świecie.", new DateTime(2024, 1, 20, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1416), 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentAuthor", "CommentContent", "CommentDate", "PostId" },
                values: new object[,]
                {
                    { 1, "Użytkownik1", "Świetny post!", new DateTime(2024, 1, 28, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1175), 1 },
                    { 2, "Użytkownik2", "Ciekawe spostrzeżenia!", new DateTime(2024, 1, 29, 2, 30, 27, 573, DateTimeKind.Local).AddTicks(1269), 1 },
                    { 3, "Użytkownik3", "Mam pytanie...", new DateTime(2024, 1, 29, 20, 30, 27, 573, DateTimeKind.Local).AddTicks(1272), 2 },
                    { 4, "Użytkownik4", "Dobrze napisane!", new DateTime(2024, 1, 30, 2, 0, 27, 573, DateTimeKind.Local).AddTicks(1277), 3 },
                    { 5, "Użytkownik5", "Zgadzam się całkowicie!", new DateTime(2024, 1, 30, 2, 30, 17, 573, DateTimeKind.Local).AddTicks(1280), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}

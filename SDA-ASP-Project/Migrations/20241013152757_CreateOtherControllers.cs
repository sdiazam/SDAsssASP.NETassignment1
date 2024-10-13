using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDA_ASP_Project.Migrations
{
    /// <inheritdoc />
    public partial class CreateOtherControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manga_ArtistId",
                table: "Manga",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_AuthorId",
                table: "Manga",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Artist_ArtistId",
                table: "Manga",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manga_Author_AuthorId",
                table: "Manga",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Artist_ArtistId",
                table: "Manga");

            migrationBuilder.DropForeignKey(
                name: "FK_Manga_Author_AuthorId",
                table: "Manga");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Manga_ArtistId",
                table: "Manga");

            migrationBuilder.DropIndex(
                name: "IX_Manga_AuthorId",
                table: "Manga");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace filmoviCrud.Migrations
{
    /// <inheritdoc />
    public partial class Vol2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReziseriFilmova");

            migrationBuilder.CreateTable(
                name: "FilmReziser",
                columns: table => new
                {
                    FilmoviId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReziseriId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmReziser", x => new { x.FilmoviId, x.ReziseriId });
                    table.ForeignKey(
                        name: "FK_FilmReziser_Filmovi_FilmoviId",
                        column: x => x.FilmoviId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmReziser_Reziseri_ReziseriId",
                        column: x => x.ReziseriId,
                        principalTable: "Reziseri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmReziser_ReziseriId",
                table: "FilmReziser",
                column: "ReziseriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmReziser");

            migrationBuilder.CreateTable(
                name: "ReziseriFilmova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReziserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReziseriFilmova", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReziseriFilmova_Filmovi_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReziseriFilmova_Reziseri_ReziserId",
                        column: x => x.ReziserId,
                        principalTable: "Reziseri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReziseriFilmova_FilmId",
                table: "ReziseriFilmova",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_ReziseriFilmova_ReziserId",
                table: "ReziseriFilmova",
                column: "ReziserId");
        }
    }
}

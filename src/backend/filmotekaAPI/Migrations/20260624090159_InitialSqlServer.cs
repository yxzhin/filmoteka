using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace filmotekaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uloga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Reziseri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzrast = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Reziseri", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Zanrovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Zanrovi", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Filmovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZanrId = table.Column<int>(type: "int", nullable: false),
                    GodinaIzdanja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Filmovi", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Filmovi_Zanrovi_ZanrId",
                        column: x => x.ZanrId,
                        principalTable: "Zanrovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "FilmReziser",
                columns: table => new
                {
                    FilmoviId = table.Column<int>(type: "int", nullable: false),
                    ReziseriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_FilmReziser", x => new { x.FilmoviId, x.ReziseriId });
                    _ = table.ForeignKey(
                        name: "FK_FilmReziser_Filmovi_FilmoviId",
                        column: x => x.FilmoviId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_FilmReziser_Reziseri_ReziseriId",
                        column: x => x.ReziseriId,
                        principalTable: "Reziseri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_Filmovi_ZanrId",
                table: "Filmovi",
                column: "ZanrId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_FilmReziser_ReziseriId",
                table: "FilmReziser",
                column: "ReziseriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "FilmReziser");

            _ = migrationBuilder.DropTable(
                name: "Korisnici");

            _ = migrationBuilder.DropTable(
                name: "Filmovi");

            _ = migrationBuilder.DropTable(
                name: "Reziseri");

            _ = migrationBuilder.DropTable(
                name: "Zanrovi");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace filmotekaAPI.Migrations
{
    /// <inheritdoc />
    public partial class FilmDostupan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Zanrovi",
                type: "nvarchar(73)",
                maxLength: 73,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Reziseri",
                type: "nvarchar(73)",
                maxLength: 73,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "Korisnici",
                type: "nvarchar(73)",
                maxLength: 73,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Korisnici",
                type: "nvarchar(73)",
                maxLength: 73,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Korisnici",
                type: "nvarchar(73)",
                maxLength: 73,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Filmovi",
                type: "nvarchar(73)",
                maxLength: 73,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Dostupan",
                table: "Filmovi",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dostupan",
                table: "Filmovi");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Zanrovi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(73)",
                oldMaxLength: 73);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Reziseri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(73)",
                oldMaxLength: 73);

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(73)",
                oldMaxLength: 73);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(73)",
                oldMaxLength: 73);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(73)",
                oldMaxLength: 73);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Filmovi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(73)",
                oldMaxLength: 73);
        }
    }
}

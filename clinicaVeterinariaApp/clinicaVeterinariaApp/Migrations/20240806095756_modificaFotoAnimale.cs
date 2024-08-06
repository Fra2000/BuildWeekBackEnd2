using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class modificaFotoAnimale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoBase64",
                table: "Ricoveri");

            migrationBuilder.AddColumn<string>(
                name: "FotoAnimale",
                table: "Animali",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoAnimale",
                table: "Animali");

            migrationBuilder.AddColumn<string>(
                name: "FotoBase64",
                table: "Ricoveri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

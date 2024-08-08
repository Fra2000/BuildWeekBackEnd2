using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPrenotazioneTokenToProprietario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrenotazioneToken",
                table: "Proprietari",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrenotazioneToken",
                table: "Proprietari");
        }
    }
}

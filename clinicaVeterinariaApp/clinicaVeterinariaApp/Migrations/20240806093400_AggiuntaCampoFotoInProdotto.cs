using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaCampoFotoInProdotto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoProdotto",
                table: "Prodotti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoProdotto",
                table: "Prodotti");
        }
    }
}

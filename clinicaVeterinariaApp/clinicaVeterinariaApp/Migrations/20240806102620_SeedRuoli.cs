using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRuoli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ruoli",
                columns: new[] { "RuoloID", "NomeRuolo" },
                values: new object[,]
                {
                    { 1, "Veterinario" },
                    { 2, "Farmacista" },
                    { 3, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ruoli",
                keyColumn: "RuoloID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ruoli",
                keyColumn: "RuoloID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ruoli",
                keyColumn: "RuoloID",
                keyValue: 3);
        }
    }
}

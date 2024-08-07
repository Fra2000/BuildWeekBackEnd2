using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class seedarmadicassetti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Armadi",
                columns: new[] { "ArmadioID", "CodiceUnivoco" },
                values: new object[,]
                {
                    { 1, "AR001" },
                    { 2, "AR002" },
                    { 3, "AR003" },
                    { 4, "AR004" },
                    { 5, "AR005" }
                });

            migrationBuilder.InsertData(
                table: "Cassetto",
                columns: new[] { "CassettoID", "ArmadioID", "NumeroCassetto" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 7, 1, 7 },
                    { 8, 1, 8 },
                    { 9, 2, 1 },
                    { 10, 2, 2 },
                    { 11, 2, 3 },
                    { 12, 2, 4 },
                    { 13, 2, 5 },
                    { 14, 2, 6 },
                    { 15, 2, 7 },
                    { 16, 2, 8 },
                    { 17, 3, 1 },
                    { 18, 3, 2 },
                    { 19, 3, 3 },
                    { 20, 3, 4 },
                    { 21, 3, 5 },
                    { 22, 3, 6 },
                    { 23, 3, 7 },
                    { 24, 3, 8 },
                    { 25, 4, 1 },
                    { 26, 4, 2 },
                    { 27, 4, 3 },
                    { 28, 4, 4 },
                    { 29, 4, 5 },
                    { 30, 4, 6 },
                    { 31, 4, 7 },
                    { 32, 4, 8 },
                    { 33, 5, 1 },
                    { 34, 5, 2 },
                    { 35, 5, 3 },
                    { 36, 5, 4 },
                    { 37, 5, 5 },
                    { 38, 5, 6 },
                    { 39, 5, 7 },
                    { 40, 5, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cassetto",
                keyColumn: "CassettoID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Armadi",
                keyColumn: "ArmadioID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Armadi",
                keyColumn: "ArmadioID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Armadi",
                keyColumn: "ArmadioID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Armadi",
                keyColumn: "ArmadioID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Armadi",
                keyColumn: "ArmadioID",
                keyValue: 5);
        }
    }
}

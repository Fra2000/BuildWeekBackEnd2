using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameClassName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cassette_Armadi_ArmadioID",
                table: "Cassette");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicinali_Cassette_CassettoID",
                table: "Medicinali");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cassette",
                table: "Cassette");

            migrationBuilder.RenameTable(
                name: "Cassette",
                newName: "Cassetto");

            migrationBuilder.RenameIndex(
                name: "IX_Cassette_ArmadioID",
                table: "Cassetto",
                newName: "IX_Cassetto_ArmadioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cassetto",
                table: "Cassetto",
                column: "CassettoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cassetto_Armadi_ArmadioID",
                table: "Cassetto",
                column: "ArmadioID",
                principalTable: "Armadi",
                principalColumn: "ArmadioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicinali_Cassetto_CassettoID",
                table: "Medicinali",
                column: "CassettoID",
                principalTable: "Cassetto",
                principalColumn: "CassettoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cassetto_Armadi_ArmadioID",
                table: "Cassetto");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicinali_Cassetto_CassettoID",
                table: "Medicinali");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cassetto",
                table: "Cassetto");

            migrationBuilder.RenameTable(
                name: "Cassetto",
                newName: "Cassette");

            migrationBuilder.RenameIndex(
                name: "IX_Cassetto_ArmadioID",
                table: "Cassette",
                newName: "IX_Cassette_ArmadioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cassette",
                table: "Cassette",
                column: "CassettoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cassette_Armadi_ArmadioID",
                table: "Cassette",
                column: "ArmadioID",
                principalTable: "Armadi",
                principalColumn: "ArmadioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicinali_Cassette_CassettoID",
                table: "Medicinali",
                column: "CassettoID",
                principalTable: "Cassette",
                principalColumn: "CassettoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

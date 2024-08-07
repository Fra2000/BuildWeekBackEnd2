using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPrenotazioneToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrenotazioneToken",
                table: "Proprietari",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Proprietari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proprietari_UserID",
                table: "Proprietari",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietari_Users_UserID",
                table: "Proprietari",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UsersID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proprietari_Users_UserID",
                table: "Proprietari");

            migrationBuilder.DropIndex(
                name: "IX_Proprietari_UserID",
                table: "Proprietari");

            migrationBuilder.DropColumn(
                name: "PrenotazioneToken",
                table: "Proprietari");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Proprietari");
        }
    }
}

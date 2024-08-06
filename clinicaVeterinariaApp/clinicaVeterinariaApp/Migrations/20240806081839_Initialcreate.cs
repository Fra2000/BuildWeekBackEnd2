using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinicaVeterinariaApp.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armadi",
                columns: table => new
                {
                    ArmadioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceUnivoco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armadi", x => x.ArmadioID);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Fornitori",
                columns: table => new
                {
                    FornitoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Recapito = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornitori", x => x.FornitoreId);
                });

            migrationBuilder.CreateTable(
                name: "Proprietari",
                columns: table => new
                {
                    ProprietarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codicefiscale = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietari", x => x.ProprietarioID);
                });

            migrationBuilder.CreateTable(
                name: "Ruoli",
                columns: table => new
                {
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRuolo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruoli", x => x.RuoloID);
                });

            migrationBuilder.CreateTable(
                name: "Cassette",
                columns: table => new
                {
                    CassettoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCassetto = table.Column<int>(type: "int", nullable: false),
                    ArmadioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassette", x => x.CassettoID);
                    table.ForeignKey(
                        name: "FK_Cassette_Armadi_ArmadioID",
                        column: x => x.ArmadioID,
                        principalTable: "Armadi",
                        principalColumn: "ArmadioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    ProdottoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ElencoUsi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PrezzoUnitario = table.Column<decimal>(type: "decimal(10,2)", maxLength: 20, nullable: false),
                    FornitoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.ProdottoID);
                    table.ForeignKey(
                        name: "FK_Prodotti_Fornitori_FornitoreId",
                        column: x => x.FornitoreId,
                        principalTable: "Fornitori",
                        principalColumn: "FornitoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animali",
                columns: table => new
                {
                    AnimaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAnimale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipologia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ColoreMantello = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MicrochipBit = table.Column<bool>(type: "bit", nullable: false),
                    MicrochipNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dataregistrazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProprietarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animali", x => x.AnimaleID);
                    table.ForeignKey(
                        name: "FK_Animali_Proprietari_ProprietarioID",
                        column: x => x.ProprietarioID,
                        principalTable: "Proprietari",
                        principalColumn: "ProprietarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CognomeUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersID);
                    table.ForeignKey(
                        name: "FK_Users_Ruoli_RuoloID",
                        column: x => x.RuoloID,
                        principalTable: "Ruoli",
                        principalColumn: "RuoloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicinali",
                columns: table => new
                {
                    MedicinaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdottoID = table.Column<int>(type: "int", nullable: false),
                    CassettoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicinali", x => x.MedicinaleID);
                    table.ForeignKey(
                        name: "FK_Medicinali_Cassette_CassettoID",
                        column: x => x.CassettoID,
                        principalTable: "Cassette",
                        principalColumn: "CassettoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicinali_Prodotti_ProdottoID",
                        column: x => x.ProdottoID,
                        principalTable: "Prodotti",
                        principalColumn: "ProdottoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendite",
                columns: table => new
                {
                    VenditaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    ProdottoID = table.Column<int>(type: "int", nullable: false),
                    DataVendita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroRicettaMedica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendite", x => x.VenditaID);
                    table.ForeignKey(
                        name: "FK_Vendite_Clienti_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clienti",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendite_Prodotti_ProdottoID",
                        column: x => x.ProdottoID,
                        principalTable: "Prodotti",
                        principalColumn: "ProdottoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ricoveri",
                columns: table => new
                {
                    RicoveriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipologia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Datainizioricovero = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFineRicovero = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimaleID = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Attivo = table.Column<bool>(type: "bit", nullable: false),
                    FotoBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ricoveri", x => x.RicoveriID);
                    table.ForeignKey(
                        name: "FK_Ricoveri_Animali_AnimaleID",
                        column: x => x.AnimaleID,
                        principalTable: "Animali",
                        principalColumn: "AnimaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visite",
                columns: table => new
                {
                    VisitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimaleID = table.Column<int>(type: "int", nullable: false),
                    DataVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsameObiettivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DescrizioneCura = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visite", x => x.VisitaID);
                    table.ForeignKey(
                        name: "FK_Visite_Animali_AnimaleID",
                        column: x => x.AnimaleID,
                        principalTable: "Animali",
                        principalColumn: "AnimaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContabilizzazioneRicoveri",
                columns: table => new
                {
                    ContabilizzazioneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RicoveroID = table.Column<int>(type: "int", nullable: false),
                    DataContabilizzazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContabilizzazioneRicoveri", x => x.ContabilizzazioneID);
                    table.ForeignKey(
                        name: "FK_ContabilizzazioneRicoveri_Ricoveri_RicoveroID",
                        column: x => x.RicoveroID,
                        principalTable: "Ricoveri",
                        principalColumn: "RicoveriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animali_ProprietarioID",
                table: "Animali",
                column: "ProprietarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Cassette_ArmadioID",
                table: "Cassette",
                column: "ArmadioID");

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_CodiceFiscale",
                table: "Clienti",
                column: "CodiceFiscale",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContabilizzazioneRicoveri_RicoveroID",
                table: "ContabilizzazioneRicoveri",
                column: "RicoveroID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicinali_CassettoID",
                table: "Medicinali",
                column: "CassettoID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicinali_ProdottoID",
                table: "Medicinali",
                column: "ProdottoID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_FornitoreId",
                table: "Prodotti",
                column: "FornitoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietari_Codicefiscale",
                table: "Proprietari",
                column: "Codicefiscale",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_AnimaleID",
                table: "Ricoveri",
                column: "AnimaleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RuoloID",
                table: "Users",
                column: "RuoloID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ClienteID",
                table: "Vendite",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ProdottoID",
                table: "Vendite",
                column: "ProdottoID");

            migrationBuilder.CreateIndex(
                name: "IX_Visite_AnimaleID",
                table: "Visite",
                column: "AnimaleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContabilizzazioneRicoveri");

            migrationBuilder.DropTable(
                name: "Medicinali");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendite");

            migrationBuilder.DropTable(
                name: "Visite");

            migrationBuilder.DropTable(
                name: "Ricoveri");

            migrationBuilder.DropTable(
                name: "Cassette");

            migrationBuilder.DropTable(
                name: "Ruoli");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Animali");

            migrationBuilder.DropTable(
                name: "Armadi");

            migrationBuilder.DropTable(
                name: "Fornitori");

            migrationBuilder.DropTable(
                name: "Proprietari");
        }
    }
}

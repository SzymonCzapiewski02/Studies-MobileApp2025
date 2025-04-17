using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Intranet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    IdProdukt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IloscMagazynowa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.IdProdukt);
                });

            migrationBuilder.CreateTable(
                name: "TattoArtists",
                columns: table => new
                {
                    IdTattoArtists = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Przydomek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LataDoswiatczenia = table.Column<int>(type: "int", nullable: false),
                    Specjalizacja = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumerKonta = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TattoArtists", x => x.IdTattoArtists);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    haslo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKlient = table.Column<int>(type: "int", nullable: false),
                    IdProduktu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Klient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Produkt_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkt",
                        principalColumn: "IdProdukt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Galeria",
                columns: table => new
                {
                    IdGaleria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTattoArtists = table.Column<int>(type: "int", nullable: false),
                    UrlZdjecia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeria", x => x.IdGaleria);
                    table.ForeignKey(
                        name: "FK_Galeria_TattoArtists_IdTattoArtists",
                        column: x => x.IdTattoArtists,
                        principalTable: "TattoArtists",
                        principalColumn: "IdTattoArtists",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzja",
                columns: table => new
                {
                    IdRecenzji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKlient = table.Column<int>(type: "int", nullable: false),
                    IdTattoArtists = table.Column<int>(type: "int", nullable: false),
                    Wartosc = table.Column<int>(type: "int", nullable: false),
                    Komentarz = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzja", x => x.IdRecenzji);
                    table.ForeignKey(
                        name: "FK_Recenzja_Klient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzja_TattoArtists_IdTattoArtists",
                        column: x => x.IdTattoArtists,
                        principalTable: "TattoArtists",
                        principalColumn: "IdTattoArtists",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    IdRezerwacja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKlient = table.Column<int>(type: "int", nullable: false),
                    IdTattoArtists = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Godzina = table.Column<TimeSpan>(type: "time", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.IdRezerwacja);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Klient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_TattoArtists_IdTattoArtists",
                        column: x => x.IdTattoArtists,
                        principalTable: "TattoArtists",
                        principalColumn: "IdTattoArtists",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tatto",
                columns: table => new
                {
                    IdTattoo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKlient = table.Column<int>(type: "int", nullable: false),
                    IdTattoArtists = table.Column<int>(type: "int", nullable: false),
                    Styl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tatto", x => x.IdTattoo);
                    table.ForeignKey(
                        name: "FK_Tatto_Klient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tatto_TattoArtists_IdTattoArtists",
                        column: x => x.IdTattoArtists,
                        principalTable: "TattoArtists",
                        principalColumn: "IdTattoArtists",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platnosc",
                columns: table => new
                {
                    IdPlatnosc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRezerwacja = table.Column<int>(type: "int", nullable: false),
                    RezerwacjeIdRezerwacja = table.Column<int>(type: "int", nullable: true),
                    Kwota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodaPlatnosci = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platnosc", x => x.IdPlatnosc);
                    table.ForeignKey(
                        name: "FK_Platnosc_Rezerwacje_RezerwacjeIdRezerwacja",
                        column: x => x.RezerwacjeIdRezerwacja,
                        principalTable: "Rezerwacje",
                        principalColumn: "IdRezerwacja");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Galeria_IdTattoArtists",
                table: "Galeria",
                column: "IdTattoArtists");

            migrationBuilder.CreateIndex(
                name: "IX_Platnosc_RezerwacjeIdRezerwacja",
                table: "Platnosc",
                column: "RezerwacjeIdRezerwacja");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzja_IdKlient",
                table: "Recenzja",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzja_IdTattoArtists",
                table: "Recenzja",
                column: "IdTattoArtists");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdKlient",
                table: "Rezerwacje",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdTattoArtists",
                table: "Rezerwacje",
                column: "IdTattoArtists");

            migrationBuilder.CreateIndex(
                name: "IX_Tatto_IdKlient",
                table: "Tatto",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Tatto_IdTattoArtists",
                table: "Tatto",
                column: "IdTattoArtists");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_IdKlient",
                table: "Zamowienia",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_IdProduktu",
                table: "Zamowienia",
                column: "IdProduktu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galeria");

            migrationBuilder.DropTable(
                name: "Platnosc");

            migrationBuilder.DropTable(
                name: "Recenzja");

            migrationBuilder.DropTable(
                name: "Tatto");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "TattoArtists");
        }
    }
}

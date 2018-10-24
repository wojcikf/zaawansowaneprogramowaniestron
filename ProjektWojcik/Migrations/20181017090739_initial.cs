using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektWojcik.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorzy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorzy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gatunki",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydawcy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawcy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tytul = table.Column<string>(nullable: true),
                    LiczbaStron = table.Column<int>(nullable: false),
                    DataPublikacji = table.Column<DateTime>(nullable: false),
                    AktulnaCena = table.Column<decimal>(nullable: false),
                    OryginalnaCena = table.Column<decimal>(nullable: false),
                    IdWydawcy = table.Column<int>(nullable: false),
                    WydawcaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Wydawcy_WydawcaId",
                        column: x => x.WydawcaId,
                        principalTable: "Wydawcy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutorzyKsiazek",
                columns: table => new
                {
                    IdAutora = table.Column<int>(nullable: false),
                    IdKsiazki = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorzyKsiazek", x => new { x.IdAutora, x.IdKsiazki });
                    table.ForeignKey(
                        name: "FK_AutorzyKsiazek_Autorzy_IdAutora",
                        column: x => x.IdAutora,
                        principalTable: "Autorzy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorzyKsiazek_Ksiazki_IdKsiazki",
                        column: x => x.IdKsiazki,
                        principalTable: "Ksiazki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorzyKsiazek_IdKsiazki",
                table: "AutorzyKsiazek",
                column: "IdKsiazki");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_WydawcaId",
                table: "Ksiazki",
                column: "WydawcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorzyKsiazek");

            migrationBuilder.DropTable(
                name: "Gatunki");

            migrationBuilder.DropTable(
                name: "Autorzy");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Wydawcy");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kerdoivkezelo.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Felhasznalo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Felhasznalo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KerdesElemek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Szoveg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KerdesElemek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kerdoivek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(nullable: true),
                    IdoKorlat = table.Column<int>(nullable: true),
                    KitoltesSzam = table.Column<int>(nullable: true),
                    AtlagPontszam = table.Column<double>(nullable: true),
                    MaxPontszam = table.Column<int>(nullable: true),
                    ElertPontszamSzumma = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kerdoivek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValaszElemek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tartalom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValaszElemek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kerdesek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KerdoivId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kerdesek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kerdesek_Kerdoivek_KerdoivId",
                        column: x => x.KerdoivId,
                        principalTable: "Kerdoivek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KerdoivKitoltesek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    KerdoivId = table.Column<int>(nullable: false),
                    FelhasznaloId = table.Column<int>(nullable: false),
                    KitoltesKezdete = table.Column<DateTimeOffset>(nullable: true),
                    KitoltesVege = table.Column<DateTimeOffset>(nullable: true),
                    Pontszam = table.Column<int>(nullable: true),
                    AktualisKerdes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KerdoivKitoltesek", x => new { x.FelhasznaloId, x.KerdoivId });
                    table.ForeignKey(
                        name: "FK_KerdoivKitoltesek_Felhasznalo_FelhasznaloId",
                        column: x => x.FelhasznaloId,
                        principalTable: "Felhasznalo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KerdoivKitoltesek_Kerdoivek_KerdoivId",
                        column: x => x.KerdoivId,
                        principalTable: "Kerdoivek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KerdesOsszerendelesek",
                columns: table => new
                {
                    KerdesId = table.Column<int>(nullable: false),
                    KerdesElemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KerdesOsszerendelesek", x => new { x.KerdesId, x.KerdesElemId });
                    table.ForeignKey(
                        name: "FK_KerdesOsszerendelesek_KerdesElemek_KerdesElemId",
                        column: x => x.KerdesElemId,
                        principalTable: "KerdesElemek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KerdesOsszerendelesek_Kerdesek_KerdesId",
                        column: x => x.KerdesId,
                        principalTable: "Kerdesek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JeloltValasz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KerdoivKitoltesekId = table.Column<int>(nullable: false),
                    KerdoivKitolteseFelhasznaloId = table.Column<int>(nullable: true),
                    KerdoivKitolteseKerdoivId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeloltValasz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JeloltValasz_KerdoivKitoltesek_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                        columns: x => new { x.KerdoivKitolteseFelhasznaloId, x.KerdoivKitolteseKerdoivId },
                        principalTable: "KerdoivKitoltesek",
                        principalColumns: new[] { "FelhasznaloId", "KerdoivId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValaszOsszerendelesek",
                columns: table => new
                {
                    ValaszElemId = table.Column<int>(nullable: false),
                    KerdesId = table.Column<int>(nullable: false),
                    JeloltValaszId = table.Column<int>(nullable: false),
                    Helyes = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValaszOsszerendelesek", x => new { x.ValaszElemId, x.KerdesId });
                    table.ForeignKey(
                        name: "FK_ValaszOsszerendelesek_JeloltValasz_JeloltValaszId",
                        column: x => x.JeloltValaszId,
                        principalTable: "JeloltValasz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValaszOsszerendelesek_Kerdesek_KerdesId",
                        column: x => x.KerdesId,
                        principalTable: "Kerdesek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValaszOsszerendelesek_ValaszElemek_ValaszElemId",
                        column: x => x.ValaszElemId,
                        principalTable: "ValaszElemek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JeloltValasz_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValasz",
                columns: new[] { "KerdoivKitolteseFelhasznaloId", "KerdoivKitolteseKerdoivId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kerdesek_KerdoivId",
                table: "Kerdesek",
                column: "KerdoivId");

            migrationBuilder.CreateIndex(
                name: "IX_KerdesOsszerendelesek_KerdesElemId",
                table: "KerdesOsszerendelesek",
                column: "KerdesElemId");

            migrationBuilder.CreateIndex(
                name: "IX_KerdoivKitoltesek_KerdoivId",
                table: "KerdoivKitoltesek",
                column: "KerdoivId");

            migrationBuilder.CreateIndex(
                name: "IX_ValaszOsszerendelesek_JeloltValaszId",
                table: "ValaszOsszerendelesek",
                column: "JeloltValaszId");

            migrationBuilder.CreateIndex(
                name: "IX_ValaszOsszerendelesek_KerdesId",
                table: "ValaszOsszerendelesek",
                column: "KerdesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KerdesOsszerendelesek");

            migrationBuilder.DropTable(
                name: "ValaszOsszerendelesek");

            migrationBuilder.DropTable(
                name: "KerdesElemek");

            migrationBuilder.DropTable(
                name: "JeloltValasz");

            migrationBuilder.DropTable(
                name: "Kerdesek");

            migrationBuilder.DropTable(
                name: "ValaszElemek");

            migrationBuilder.DropTable(
                name: "KerdoivKitoltesek");

            migrationBuilder.DropTable(
                name: "Felhasznalo");

            migrationBuilder.DropTable(
                name: "Kerdoivek");
        }
    }
}

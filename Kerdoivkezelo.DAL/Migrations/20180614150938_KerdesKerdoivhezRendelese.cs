using Microsoft.EntityFrameworkCore.Migrations;

namespace Kerdoivkezelo.DAL.Migrations
{
    public partial class KerdesKerdoivhezRendelese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JeloltValasz_KerdoivKitoltesek_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValasz");

            migrationBuilder.DropForeignKey(
                name: "FK_Kerdesek_Kerdoivek_KerdoivId",
                table: "Kerdesek");

            migrationBuilder.DropForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValasz_JeloltValaszId",
                table: "ValaszOsszerendelesek");

            migrationBuilder.DropIndex(
                name: "IX_Kerdesek_KerdoivId",
                table: "Kerdesek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JeloltValasz",
                table: "JeloltValasz");

            migrationBuilder.DropColumn(
                name: "KerdoivId",
                table: "Kerdesek");

            migrationBuilder.RenameTable(
                name: "JeloltValasz",
                newName: "JeloltValaszok");

            migrationBuilder.RenameIndex(
                name: "IX_JeloltValasz_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValaszok",
                newName: "IX_JeloltValaszok_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JeloltValaszok",
                table: "JeloltValaszok",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KerdoivKerdesek",
                columns: table => new
                {
                    KerdesId = table.Column<int>(nullable: false),
                    KerdoivId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KerdoivKerdesek", x => new { x.KerdesId, x.KerdoivId });
                    table.ForeignKey(
                        name: "FK_KerdoivKerdesek_Kerdesek_KerdesId",
                        column: x => x.KerdesId,
                        principalTable: "Kerdesek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KerdoivKerdesek_Kerdoivek_KerdoivId",
                        column: x => x.KerdoivId,
                        principalTable: "Kerdoivek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KerdoivKerdesek_KerdoivId",
                table: "KerdoivKerdesek",
                column: "KerdoivId");

            migrationBuilder.AddForeignKey(
                name: "FK_JeloltValaszok_KerdoivKitoltesek_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValaszok",
                columns: new[] { "KerdoivKitolteseFelhasznaloId", "KerdoivKitolteseKerdoivId" },
                principalTable: "KerdoivKitoltesek",
                principalColumns: new[] { "FelhasznaloId", "KerdoivId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValaszok_JeloltValaszId",
                table: "ValaszOsszerendelesek",
                column: "JeloltValaszId",
                principalTable: "JeloltValaszok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JeloltValaszok_KerdoivKitoltesek_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValaszok");

            migrationBuilder.DropForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValaszok_JeloltValaszId",
                table: "ValaszOsszerendelesek");

            migrationBuilder.DropTable(
                name: "KerdoivKerdesek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JeloltValaszok",
                table: "JeloltValaszok");

            migrationBuilder.RenameTable(
                name: "JeloltValaszok",
                newName: "JeloltValasz");

            migrationBuilder.RenameIndex(
                name: "IX_JeloltValaszok_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValasz",
                newName: "IX_JeloltValasz_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId");

            migrationBuilder.AddColumn<int>(
                name: "KerdoivId",
                table: "Kerdesek",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JeloltValasz",
                table: "JeloltValasz",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kerdesek_KerdoivId",
                table: "Kerdesek",
                column: "KerdoivId");

            migrationBuilder.AddForeignKey(
                name: "FK_JeloltValasz_KerdoivKitoltesek_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValasz",
                columns: new[] { "KerdoivKitolteseFelhasznaloId", "KerdoivKitolteseKerdoivId" },
                principalTable: "KerdoivKitoltesek",
                principalColumns: new[] { "FelhasznaloId", "KerdoivId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kerdesek_Kerdoivek_KerdoivId",
                table: "Kerdesek",
                column: "KerdoivId",
                principalTable: "Kerdoivek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValasz_JeloltValaszId",
                table: "ValaszOsszerendelesek",
                column: "JeloltValaszId",
                principalTable: "JeloltValasz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Kerdoivkezelo.DAL.Migrations
{
    public partial class ValaszOsszerendelesbolJeloltValaszFKtorolve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValaszok_JeloltValaszId",
                table: "ValaszOsszerendelesek");

            migrationBuilder.AlterColumn<int>(
                name: "JeloltValaszId",
                table: "ValaszOsszerendelesek",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValaszok_JeloltValaszId",
                table: "ValaszOsszerendelesek",
                column: "JeloltValaszId",
                principalTable: "JeloltValaszok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValaszok_JeloltValaszId",
                table: "ValaszOsszerendelesek");

            migrationBuilder.AlterColumn<int>(
                name: "JeloltValaszId",
                table: "ValaszOsszerendelesek",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ValaszOsszerendelesek_JeloltValaszok_JeloltValaszId",
                table: "ValaszOsszerendelesek",
                column: "JeloltValaszId",
                principalTable: "JeloltValaszok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

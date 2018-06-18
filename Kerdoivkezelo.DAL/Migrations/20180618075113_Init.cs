using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kerdoivkezelo.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kerdesek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kerdesek", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KerdoivKitoltesek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    KerdoivId = table.Column<int>(nullable: false),
                    FelhasznaloId = table.Column<int>(nullable: false),
                    FelhasznaloId1 = table.Column<string>(nullable: true),
                    KitoltesKezdete = table.Column<DateTimeOffset>(nullable: true),
                    KitoltesVege = table.Column<DateTimeOffset>(nullable: true),
                    Pontszam = table.Column<int>(nullable: true),
                    AktualisKerdes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KerdoivKitoltesek", x => new { x.FelhasznaloId, x.KerdoivId });
                    table.ForeignKey(
                        name: "FK_KerdoivKitoltesek_Users_FelhasznaloId1",
                        column: x => x.FelhasznaloId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KerdoivKitoltesek_Kerdoivek_KerdoivId",
                        column: x => x.KerdoivId,
                        principalTable: "Kerdoivek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JeloltValaszok",
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
                    table.PrimaryKey("PK_JeloltValaszok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JeloltValaszok_KerdoivKitoltesek_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
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
                    Helyes = table.Column<bool>(nullable: false),
                    JeloltValaszId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValaszOsszerendelesek", x => new { x.ValaszElemId, x.KerdesId });
                    table.ForeignKey(
                        name: "FK_ValaszOsszerendelesek_JeloltValaszok_JeloltValaszId",
                        column: x => x.JeloltValaszId,
                        principalTable: "JeloltValaszok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_JeloltValaszok_KerdoivKitolteseFelhasznaloId_KerdoivKitolteseKerdoivId",
                table: "JeloltValaszok",
                columns: new[] { "KerdoivKitolteseFelhasznaloId", "KerdoivKitolteseKerdoivId" });

            migrationBuilder.CreateIndex(
                name: "IX_KerdesOsszerendelesek_KerdesElemId",
                table: "KerdesOsszerendelesek",
                column: "KerdesElemId");

            migrationBuilder.CreateIndex(
                name: "IX_KerdoivKerdesek_KerdoivId",
                table: "KerdoivKerdesek",
                column: "KerdoivId");

            migrationBuilder.CreateIndex(
                name: "IX_KerdoivKitoltesek_FelhasznaloId1",
                table: "KerdoivKitoltesek",
                column: "FelhasznaloId1");

            migrationBuilder.CreateIndex(
                name: "IX_KerdoivKitoltesek_KerdoivId",
                table: "KerdoivKitoltesek",
                column: "KerdoivId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KerdesOsszerendelesek");

            migrationBuilder.DropTable(
                name: "KerdoivKerdesek");

            migrationBuilder.DropTable(
                name: "ValaszOsszerendelesek");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "KerdesElemek");

            migrationBuilder.DropTable(
                name: "JeloltValaszok");

            migrationBuilder.DropTable(
                name: "Kerdesek");

            migrationBuilder.DropTable(
                name: "ValaszElemek");

            migrationBuilder.DropTable(
                name: "KerdoivKitoltesek");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Kerdoivek");
        }
    }
}

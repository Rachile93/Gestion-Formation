using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionFormation.Migrations
{
    public partial class newMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "formateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Prenom = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    Tel = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "formations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    Cathégorie = table.Column<string>(type: "text", nullable: true),
                    module = table.Column<string>(type: "text", nullable: true),
                    Nombre_de_periode = table.Column<int>(type: "integer", nullable: false),
                    Date_debut = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Date_fin = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FormateurId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_formations_formateurs_FormateurId",
                        column: x => x.FormateurId,
                        principalTable: "formateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_formations_FormateurId",
                table: "formations",
                column: "FormateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "formations");

            migrationBuilder.DropTable(
                name: "formateurs");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionFormation.Migrations
{
    public partial class newMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cathégorie",
                table: "formations",
                newName: "Categorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categorie",
                table: "formations",
                newName: "Cathégorie");
        }
    }
}

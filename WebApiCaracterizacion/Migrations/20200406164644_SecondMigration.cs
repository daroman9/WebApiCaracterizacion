using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "disableFields",
                table: "Tablas_Campos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreCampaña",
                table: "Formularios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "disableFields",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "nombreCampaña",
                table: "Formularios");
        }
    }
}

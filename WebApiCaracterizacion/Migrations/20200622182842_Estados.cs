using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class Estados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Registros_Tablas");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Registros");

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "Ficha",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Ficha");

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "Registros_Tablas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "Registros",
                nullable: true);
        }
    }
}

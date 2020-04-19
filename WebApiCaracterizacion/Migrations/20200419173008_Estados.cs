using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class Estados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "Registros_Tablas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "Registros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Registros_Tablas");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Registros");
        }
    }
}

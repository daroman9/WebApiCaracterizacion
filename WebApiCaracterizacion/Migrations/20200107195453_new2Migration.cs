using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class new2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "order",
                table: "Campos",
                newName: "orden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "orden",
                table: "Campos",
                newName: "order");
        }
    }
}

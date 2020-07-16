using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class ordenColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "color",
                table: "Selector_Detail",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "orden",
                table: "Selector_Detail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "Selector_Detail");

            migrationBuilder.DropColumn(
                name: "orden",
                table: "Selector_Detail");
        }
    }
}

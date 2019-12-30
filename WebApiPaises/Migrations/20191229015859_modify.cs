using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiPaises.Migrations
{
    public partial class modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Categorias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categorias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Visible",
                table: "Categorias",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class codRecovery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codRecovery",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codRecovery",
                table: "AspNetUsers");
        }
    }
}

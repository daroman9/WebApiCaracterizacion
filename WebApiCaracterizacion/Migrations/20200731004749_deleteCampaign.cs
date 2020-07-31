using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class deleteCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_fin",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "fecha_inicio",
                table: "Campaign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_fin",
                table: "Campaign",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_inicio",
                table: "Campaign",
                nullable: true);
        }
    }
}

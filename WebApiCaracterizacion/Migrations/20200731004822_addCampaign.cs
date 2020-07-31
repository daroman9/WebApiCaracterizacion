using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class addCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
               name: "fecha_inicio",
               table: "Campaign",
               nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_fin",
                table: "Campaign",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "fecha_inicio",
               table: "Campaign");

            migrationBuilder.DropColumn(
                name: "fecha_fin",
                table: "Campaign");

        }
    }
}

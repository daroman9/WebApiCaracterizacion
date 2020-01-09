using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class MigracionFicha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id_ficha",
                table: "Registros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registros_id_ficha",
                table: "Registros",
                column: "id_ficha");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Ficha_id_ficha",
                table: "Registros",
                column: "id_ficha",
                principalTable: "Ficha",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Ficha_id_ficha",
                table: "Registros");

            migrationBuilder.DropIndex(
                name: "IX_Registros_id_ficha",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "id_ficha",
                table: "Registros");
        }
    }
}

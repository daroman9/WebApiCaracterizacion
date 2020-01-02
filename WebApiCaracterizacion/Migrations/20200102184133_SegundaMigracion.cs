using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formularios_Plantillas_plantillaid",
                table: "Formularios");

            migrationBuilder.DropIndex(
                name: "IX_Formularios_plantillaid",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "plantillaid",
                table: "Formularios");

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_id_plantilla",
                table: "Formularios",
                column: "id_plantilla");

            migrationBuilder.AddForeignKey(
                name: "FK_Formularios_Plantillas_id_plantilla",
                table: "Formularios",
                column: "id_plantilla",
                principalTable: "Plantillas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formularios_Plantillas_id_plantilla",
                table: "Formularios");

            migrationBuilder.DropIndex(
                name: "IX_Formularios_id_plantilla",
                table: "Formularios");

            migrationBuilder.AddColumn<int>(
                name: "plantillaid",
                table: "Formularios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_plantillaid",
                table: "Formularios",
                column: "plantillaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Formularios_Plantillas_plantillaid",
                table: "Formularios",
                column: "plantillaid",
                principalTable: "Plantillas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

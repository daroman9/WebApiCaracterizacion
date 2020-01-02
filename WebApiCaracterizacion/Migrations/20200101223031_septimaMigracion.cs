using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class septimaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Campos_id_categoria",
                table: "Campos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Campos_id_plantilla",
                table: "Campos",
                column: "id_plantilla");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Categorias_id_categoria",
                table: "Campos",
                column: "id_categoria",
                principalTable: "Categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Plantillas_id_plantilla",
                table: "Campos",
                column: "id_plantilla",
                principalTable: "Plantillas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Categorias_id_categoria",
                table: "Campos");

            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Plantillas_id_plantilla",
                table: "Campos");

            migrationBuilder.DropIndex(
                name: "IX_Campos_id_categoria",
                table: "Campos");

            migrationBuilder.DropIndex(
                name: "IX_Campos_id_plantilla",
                table: "Campos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class correctionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categorias_id_formulario",
                table: "Categorias",
                column: "id_formulario");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Formularios_id_formulario",
                table: "Categorias",
                column: "id_formulario",
                principalTable: "Formularios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Formularios_id_formulario",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_id_formulario",
                table: "Categorias");
        }
    }
}

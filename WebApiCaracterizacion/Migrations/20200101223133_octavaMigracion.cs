using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class octavaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tablas_Campos_id_campo",
                table: "Tablas_Campos",
                column: "id_campo");

            migrationBuilder.CreateIndex(
                name: "IX_Selectores_id_campo",
                table: "Selectores",
                column: "id_campo");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Tablas_id_formulario",
                table: "Registros_Tablas",
                column: "id_formulario");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Tablas_Formularios_id_formulario",
                table: "Registros_Tablas",
                column: "id_formulario",
                principalTable: "Formularios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selectores_Campos_id_campo",
                table: "Selectores",
                column: "id_campo",
                principalTable: "Campos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tablas_Campos_Campos_id_campo",
                table: "Tablas_Campos",
                column: "id_campo",
                principalTable: "Campos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Tablas_Formularios_id_formulario",
                table: "Registros_Tablas");

            migrationBuilder.DropForeignKey(
                name: "FK_Selectores_Campos_id_campo",
                table: "Selectores");

            migrationBuilder.DropForeignKey(
                name: "FK_Tablas_Campos_Campos_id_campo",
                table: "Tablas_Campos");

            migrationBuilder.DropIndex(
                name: "IX_Tablas_Campos_id_campo",
                table: "Tablas_Campos");

            migrationBuilder.DropIndex(
                name: "IX_Selectores_id_campo",
                table: "Selectores");

            migrationBuilder.DropIndex(
                name: "IX_Registros_Tablas_id_formulario",
                table: "Registros_Tablas");
        }
    }
}

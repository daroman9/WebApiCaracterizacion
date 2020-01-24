using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class TablasCampoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_registro_tabla_campo",
                table: "Registros_Tablas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Tablas_id_registro_tabla_campo",
                table: "Registros_Tablas",
                column: "id_registro_tabla_campo");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Tablas_Tablas_Campos_id_registro_tabla_campo",
                table: "Registros_Tablas",
                column: "id_registro_tabla_campo",
                principalTable: "Tablas_Campos",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Tablas_Tablas_Campos_id_registro_tabla_campo",
                table: "Registros_Tablas");

            migrationBuilder.DropIndex(
                name: "IX_Registros_Tablas_id_registro_tabla_campo",
                table: "Registros_Tablas");

            migrationBuilder.DropColumn(
                name: "id_registro_tabla_campo",
                table: "Registros_Tablas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class AgregarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Tablas_Tablas_Campos_Tablas_CampoID",
                table: "Registros_Tablas");

            migrationBuilder.DropIndex(
                name: "IX_Registros_Tablas_Tablas_CampoID",
                table: "Registros_Tablas");

            migrationBuilder.DropColumn(
                name: "Tablas_CampoID",
                table: "Registros_Tablas");

            migrationBuilder.AddColumn<int>(
                name: "ID_Tablas_Campo",
                table: "Registros_Tablas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Tablas_ID_Tablas_Campo",
                table: "Registros_Tablas",
                column: "ID_Tablas_Campo");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Tablas_Tablas_Campos_ID_Tablas_Campo",
                table: "Registros_Tablas",
                column: "ID_Tablas_Campo",
                principalTable: "Tablas_Campos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Tablas_Tablas_Campos_ID_Tablas_Campo",
                table: "Registros_Tablas");

            migrationBuilder.DropIndex(
                name: "IX_Registros_Tablas_ID_Tablas_Campo",
                table: "Registros_Tablas");

            migrationBuilder.DropColumn(
                name: "ID_Tablas_Campo",
                table: "Registros_Tablas");

            migrationBuilder.AddColumn<int>(
                name: "Tablas_CampoID",
                table: "Registros_Tablas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Tablas_Tablas_CampoID",
                table: "Registros_Tablas",
                column: "Tablas_CampoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Tablas_Tablas_Campos_Tablas_CampoID",
                table: "Registros_Tablas",
                column: "Tablas_CampoID",
                principalTable: "Tablas_Campos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

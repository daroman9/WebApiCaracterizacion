using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class CorrecionValidacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Ficha_id_validacion",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Tablas_Ficha_id_validacion",
                table: "Registros_Tablas");

            migrationBuilder.DropIndex(
                name: "IX_Registros_Tablas_id_validacion",
                table: "Registros_Tablas");

            migrationBuilder.DropIndex(
                name: "IX_Registros_id_validacion",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "id_validacion",
                table: "Registros_Tablas");

            migrationBuilder.DropColumn(
                name: "id_validacion",
                table: "Registros");

            migrationBuilder.AddColumn<int>(
                name: "id_validacion",
                table: "Tablas_Campos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_validacion",
                table: "Campos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tablas_Campos_id_validacion",
                table: "Tablas_Campos",
                column: "id_validacion");

            migrationBuilder.CreateIndex(
                name: "IX_Campos_id_validacion",
                table: "Campos",
                column: "id_validacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Validacion_id_validacion",
                table: "Campos",
                column: "id_validacion",
                principalTable: "Validacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tablas_Campos_Validacion_id_validacion",
                table: "Tablas_Campos",
                column: "id_validacion",
                principalTable: "Validacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Validacion_id_validacion",
                table: "Campos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tablas_Campos_Validacion_id_validacion",
                table: "Tablas_Campos");

            migrationBuilder.DropIndex(
                name: "IX_Tablas_Campos_id_validacion",
                table: "Tablas_Campos");

            migrationBuilder.DropIndex(
                name: "IX_Campos_id_validacion",
                table: "Campos");

            migrationBuilder.DropColumn(
                name: "id_validacion",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "id_validacion",
                table: "Campos");

            migrationBuilder.AddColumn<string>(
                name: "id_validacion",
                table: "Registros_Tablas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id_validacion",
                table: "Registros",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Tablas_id_validacion",
                table: "Registros_Tablas",
                column: "id_validacion");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_id_validacion",
                table: "Registros",
                column: "id_validacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Ficha_id_validacion",
                table: "Registros",
                column: "id_validacion",
                principalTable: "Ficha",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Tablas_Ficha_id_validacion",
                table: "Registros_Tablas",
                column: "id_validacion",
                principalTable: "Ficha",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

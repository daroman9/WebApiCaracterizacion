using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class IdSelector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_selector",
                table: "Tablas_Campos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tablas_Campos_id_selector",
                table: "Tablas_Campos",
                column: "id_selector");

            migrationBuilder.AddForeignKey(
                name: "FK_Tablas_Campos_Selectores_id_selector",
                table: "Tablas_Campos",
                column: "id_selector",
                principalTable: "Selectores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tablas_Campos_Selectores_id_selector",
                table: "Tablas_Campos");

            migrationBuilder.DropIndex(
                name: "IX_Tablas_Campos_id_selector",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "id_selector",
                table: "Tablas_Campos");
        }
    }
}

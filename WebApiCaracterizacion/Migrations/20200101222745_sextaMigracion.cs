using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class sextaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Registros_id_campo",
                table: "Registros",
                column: "id_campo");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Campos_id_campo",
                table: "Registros",
                column: "id_campo",
                principalTable: "Campos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Campos_id_campo",
                table: "Registros");

            migrationBuilder.DropIndex(
                name: "IX_Registros_id_campo",
                table: "Registros");
        }
    }
}

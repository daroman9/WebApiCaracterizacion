using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class ForeignProfesionales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_profesional",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_id_profesional",
                table: "AspNetUsers",
                column: "id_profesional");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profesionales_id_profesional",
                table: "AspNetUsers",
                column: "id_profesional",
                principalTable: "Profesionales",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profesionales_id_profesional",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_id_profesional",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "id_profesional",
                table: "AspNetUsers");
        }
    }
}

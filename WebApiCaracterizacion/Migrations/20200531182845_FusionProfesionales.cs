using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class FusionProfesionales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesionalesXCampana_Profesionales_id_profesional",
                table: "ProfesionalesXCampana");

            migrationBuilder.DropTable(
                name: "Profesionales");

            migrationBuilder.DropIndex(
                name: "IX_ProfesionalesXCampana_id_profesional",
                table: "ProfesionalesXCampana");

            migrationBuilder.DropColumn(
                name: "id_profesional",
                table: "ProfesionalesXCampana");

            migrationBuilder.AddColumn<string>(
                name: "id_usuario",
                table: "ProfesionalesXCampana",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalesXCampana_id_usuario",
                table: "ProfesionalesXCampana",
                column: "id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesionalesXCampana_AspNetUsers_id_usuario",
                table: "ProfesionalesXCampana",
                column: "id_usuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesionalesXCampana_AspNetUsers_id_usuario",
                table: "ProfesionalesXCampana");

            migrationBuilder.DropIndex(
                name: "IX_ProfesionalesXCampana_id_usuario",
                table: "ProfesionalesXCampana");

            migrationBuilder.DropColumn(
                name: "id_usuario",
                table: "ProfesionalesXCampana");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "id_profesional",
                table: "ProfesionalesXCampana",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profesionales",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    apellido = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    foto = table.Column<string>(nullable: true),
                    identificacion = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    profesion = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesionales", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalesXCampana_id_profesional",
                table: "ProfesionalesXCampana",
                column: "id_profesional");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesionalesXCampana_Profesionales_id_profesional",
                table: "ProfesionalesXCampana",
                column: "id_profesional",
                principalTable: "Profesionales",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

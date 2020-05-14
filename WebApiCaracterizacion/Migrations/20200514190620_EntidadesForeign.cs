using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class EntidadesForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfesionalesXCampana",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_entidad = table.Column<int>(nullable: false),
                    id_profesional = table.Column<int>(nullable: false),
                    id_plantilla = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalesXCampana", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProfesionalesXCampana_EntidadesXCampana_id_entidad",
                        column: x => x.id_entidad,
                        principalTable: "EntidadesXCampana",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesionalesXCampana_Profesionales_id_profesional",
                        column: x => x.id_profesional,
                        principalTable: "Profesionales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalesXCampana_id_entidad",
                table: "ProfesionalesXCampana",
                column: "id_entidad");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalesXCampana_id_profesional",
                table: "ProfesionalesXCampana",
                column: "id_profesional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfesionalesXCampana");
        }
    }
}

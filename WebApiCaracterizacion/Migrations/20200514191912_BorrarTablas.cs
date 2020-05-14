using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class BorrarTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "OtraTabla");

            migrationBuilder.DropTable(
                name: "TablaPrueba");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "OtraTabla",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    otra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtraTabla", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TablaPrueba",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prueba = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaPrueba", x => x.id);
                });
        }
    }
}

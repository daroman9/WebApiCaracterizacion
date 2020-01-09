using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Selector_Detail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valor = table.Column<string>(nullable: true),
                    etiqueta = table.Column<string>(nullable: true),
                    id_selector = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selector_Detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_Selector_Detail_Selectores_id_selector",
                        column: x => x.id_selector,
                        principalTable: "Selectores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selector_Detail_id_selector",
                table: "Selector_Detail",
                column: "id_selector");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Selector_Detail");
        }
    }
}

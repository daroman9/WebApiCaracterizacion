using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class Validaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id_validacion",
                table: "Registros_Tablas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id_validacion",
                table: "Registros",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Validacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    validacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validacion", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Ficha_id_validacion",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Tablas_Ficha_id_validacion",
                table: "Registros_Tablas");

            migrationBuilder.DropTable(
                name: "Validacion");

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class TablasCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "Tablas_Campos",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orden",
                table: "Tablas_Campos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "rangos",
                table: "Tablas_Campos",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unidad",
                table: "Tablas_Campos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "valor_defecto",
                table: "Tablas_Campos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "valor_maximo",
                table: "Tablas_Campos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "valor_minimo",
                table: "Tablas_Campos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "visible",
                table: "Tablas_Campos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orden",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "rangos",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "unidad",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "valor_defecto",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "valor_maximo",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "valor_minimo",
                table: "Tablas_Campos");

            migrationBuilder.DropColumn(
                name: "visible",
                table: "Tablas_Campos");

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "Tablas_Campos",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}

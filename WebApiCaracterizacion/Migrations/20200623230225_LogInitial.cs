using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class LogInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: true),
                    estadoInicial = table.Column<string>(nullable: true),
                    estadoFinal = table.Column<string>(nullable: true),
                    camposCambiado = table.Column<string>(nullable: true),
                    valorAnterior = table.Column<string>(nullable: true),
                    valorNuevo = table.Column<string>(nullable: true),
                    noConformidades = table.Column<int>(nullable: false),
                    id_usuario = table.Column<string>(nullable: true),
                    id_ficha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.id);
                    table.ForeignKey(
                        name: "FK_Log_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_id_ficha",
                table: "Log",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Log_id_usuario",
                table: "Log",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}

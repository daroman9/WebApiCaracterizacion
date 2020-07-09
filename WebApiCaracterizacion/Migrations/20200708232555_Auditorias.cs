using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class Auditorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Ficha_id_ficha",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_AspNetUsers_id_usuario",
                table: "Log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Log");

            migrationBuilder.RenameTable(
                name: "Log",
                newName: "Log_Auditoria");

            migrationBuilder.RenameIndex(
                name: "IX_Log_id_usuario",
                table: "Log_Auditoria",
                newName: "IX_Log_Auditoria_id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Log_id_ficha",
                table: "Log_Auditoria",
                newName: "IX_Log_Auditoria_id_ficha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log_Auditoria",
                table: "Log_Auditoria",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Rastro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_ficha = table.Column<string>(nullable: true),
                    estadoInicial = table.Column<string>(nullable: true),
                    estadoFinal = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    id_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rastro", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rastro_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rastro_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Revision_Ajuste",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_ficha = table.Column<string>(nullable: true),
                    estadoInicial = table.Column<string>(nullable: true),
                    estadoFinal = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    id_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revision_Ajuste", x => x.id);
                    table.ForeignKey(
                        name: "FK_Revision_Ajuste_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Revision_Ajuste_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rastro_id_ficha",
                table: "Rastro",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Rastro_id_usuario",
                table: "Rastro",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_Ajuste_id_ficha",
                table: "Revision_Ajuste",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_Ajuste_id_usuario",
                table: "Revision_Ajuste",
                column: "id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Auditoria_Ficha_id_ficha",
                table: "Log_Auditoria",
                column: "id_ficha",
                principalTable: "Ficha",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Auditoria_AspNetUsers_id_usuario",
                table: "Log_Auditoria",
                column: "id_usuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Auditoria_Ficha_id_ficha",
                table: "Log_Auditoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Auditoria_AspNetUsers_id_usuario",
                table: "Log_Auditoria");

            migrationBuilder.DropTable(
                name: "Rastro");

            migrationBuilder.DropTable(
                name: "Revision_Ajuste");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Log_Auditoria",
                table: "Log_Auditoria");

            migrationBuilder.RenameTable(
                name: "Log_Auditoria",
                newName: "Log");

            migrationBuilder.RenameIndex(
                name: "IX_Log_Auditoria_id_usuario",
                table: "Log",
                newName: "IX_Log_id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Log_Auditoria_id_ficha",
                table: "Log",
                newName: "IX_Log_id_ficha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Log",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Ficha_id_ficha",
                table: "Log",
                column: "id_ficha",
                principalTable: "Ficha",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_AspNetUsers_id_usuario",
                table: "Log",
                column: "id_usuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class foreignCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_campaign",
                table: "Formularios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_id_campaign",
                table: "Formularios",
                column: "id_campaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Formularios_Campaign_id_campaign",
                table: "Formularios",
                column: "id_campaign",
                principalTable: "Campaign",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formularios_Campaign_id_campaign",
                table: "Formularios");

            migrationBuilder.DropIndex(
                name: "IX_Formularios_id_campaign",
                table: "Formularios");

            migrationBuilder.DropColumn(
                name: "id_campaign",
                table: "Formularios");
        }
    }
}

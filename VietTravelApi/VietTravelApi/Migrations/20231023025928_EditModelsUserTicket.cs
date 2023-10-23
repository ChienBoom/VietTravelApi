using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class EditModelsUserTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_user_UserId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_UserId",
                table: "ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ticket_UserId",
                table: "ticket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_user_UserId",
                table: "ticket",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

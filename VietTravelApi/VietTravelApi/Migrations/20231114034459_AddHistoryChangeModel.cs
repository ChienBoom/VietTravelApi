using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class AddHistoryChangeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "historyChangeStatusTicket",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeChange = table.Column<DateTime>(nullable: false),
                    ChangeBy = table.Column<long>(nullable: false),
                    TicketId = table.Column<long>(nullable: false),
                    oldStatus = table.Column<int>(nullable: false),
                    newStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historyChangeStatusTicket", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historyChangeStatusTicket");
        }
    }
}

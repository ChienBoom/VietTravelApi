using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class addEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "PriceTicket",
                table: "Schedule");

            migrationBuilder.AlterColumn<int>(
                name: "TicketEnable",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceTicketAdult",
                table: "Schedule",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceTicketKid",
                table: "Schedule",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Schedule",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "TourPackageId",
                table: "Schedule",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "PriceTicketAdult",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "PriceTicketKid",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TourPackageId",
                table: "Schedule");

            migrationBuilder.AlterColumn<bool>(
                name: "TicketEnable",
                table: "Schedule",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Schedule",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceTicket",
                table: "Schedule",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

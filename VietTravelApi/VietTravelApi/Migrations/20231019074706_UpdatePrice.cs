using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class UpdatePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceBase",
                table: "tour",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceTourGuide",
                table: "tour",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "tour",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "HourNumber",
                table: "timepackage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceDefault",
                table: "restaurant",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceHour",
                table: "hotel",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceBase",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "PriceTourGuide",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "HourNumber",
                table: "timepackage");

            migrationBuilder.DropColumn(
                name: "PriceDefault",
                table: "restaurant");

            migrationBuilder.DropColumn(
                name: "PriceHour",
                table: "hotel");
        }
    }
}

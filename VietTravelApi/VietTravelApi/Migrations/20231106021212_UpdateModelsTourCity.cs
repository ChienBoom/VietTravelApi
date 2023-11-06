using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class UpdateModelsTourCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "city");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "city");

            migrationBuilder.AddColumn<string>(
                name: "CoordLat",
                table: "tour",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoordLon",
                table: "tour",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoordLat",
                table: "city",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoordLon",
                table: "city",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordLat",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "CoordLon",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "CoordLat",
                table: "city");

            migrationBuilder.DropColumn(
                name: "CoordLon",
                table: "city");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "tour",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tour",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "city",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "city",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class IsDeleteModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "user",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "tourpackage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "tourguide",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "tour",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "timepackage",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "hotel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "evaluate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "city",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "tourpackage");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "tourguide");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "timepackage");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "restaurant");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "event");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "city");
        }
    }
}

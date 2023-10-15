using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class UpdateUniCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniCodeName",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniCodeName",
                table: "tour",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniCodeName",
                table: "restaurant",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniCodeName",
                table: "hotel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniCodeName",
                table: "city",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniCodeName",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UniCodeName",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "UniCodeName",
                table: "restaurant");

            migrationBuilder.DropColumn(
                name: "UniCodeName",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "UniCodeName",
                table: "city");
        }
    }
}

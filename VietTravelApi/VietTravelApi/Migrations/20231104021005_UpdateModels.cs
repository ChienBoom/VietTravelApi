using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "MediumStar",
                table: "restaurant",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluate",
                table: "restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MediumStar",
                table: "hotel",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluate",
                table: "hotel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MediumStar",
                table: "city",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluate",
                table: "city",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediumStar",
                table: "restaurant");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluate",
                table: "restaurant");

            migrationBuilder.DropColumn(
                name: "MediumStar",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluate",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "MediumStar",
                table: "city");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluate",
                table: "city");
        }
    }
}

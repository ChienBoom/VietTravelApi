using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class UpdateNumberOfValueStar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluateStar",
                table: "tour",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluateStar",
                table: "restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluateStar",
                table: "hotel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NumberStar",
                table: "evaluateStar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluateStar",
                table: "city",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEvaluateStar",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluateStar",
                table: "restaurant");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluateStar",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluateStar",
                table: "city");

            migrationBuilder.AlterColumn<string>(
                name: "NumberStar",
                table: "evaluateStar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

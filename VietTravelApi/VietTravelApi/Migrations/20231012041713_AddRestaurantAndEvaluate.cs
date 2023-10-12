using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class AddRestaurantAndEvaluate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_tour_TourId",
                table: "evaluate");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_TourId",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "MediumStar",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluate",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "evaluate");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "evaluate",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Eva",
                table: "evaluate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "EvaId",
                table: "evaluate",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "Eva",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "EvaId",
                table: "evaluate");

            migrationBuilder.AddColumn<float>(
                name: "MediumStar",
                table: "evaluate",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluate",
                table: "evaluate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TourId",
                table: "evaluate",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_TourId",
                table: "evaluate",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluate_tour_TourId",
                table: "evaluate",
                column: "TourId",
                principalTable: "tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

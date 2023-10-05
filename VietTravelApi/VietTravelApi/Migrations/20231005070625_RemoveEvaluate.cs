using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class RemoveEvaluate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tour_evaluate_EvaluateId",
                table: "tour");

            migrationBuilder.DropIndex(
                name: "IX_tour_EvaluateId",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "EvaluateId",
                table: "tour");

            migrationBuilder.AddColumn<float>(
                name: "MediumStar",
                table: "tour",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEvaluate",
                table: "tour",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TourId",
                table: "evaluate",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_tour_TourId",
                table: "evaluate");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_TourId",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "MediumStar",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "NumberOfEvaluate",
                table: "tour");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "evaluate");

            migrationBuilder.AddColumn<long>(
                name: "EvaluateId",
                table: "tour",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tour_EvaluateId",
                table: "tour",
                column: "EvaluateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tour_evaluate_EvaluateId",
                table: "tour",
                column: "EvaluateId",
                principalTable: "evaluate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

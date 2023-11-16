using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class dependenci_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tourguide_CityId",
                table: "tourguide",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_CityId",
                table: "restaurant",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_CityId",
                table: "hotel",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluateStar_EvaId",
                table: "evaluateStar",
                column: "EvaId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_EvaId",
                table: "evaluate",
                column: "EvaId");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluate_city_EvaId",
                table: "evaluate",
                column: "EvaId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluateStar_city_EvaId",
                table: "evaluateStar",
                column: "EvaId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_city_CityId",
                table: "hotel",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_restaurant_city_CityId",
                table: "restaurant",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tourguide_city_CityId",
                table: "tourguide",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_city_EvaId",
                table: "evaluate");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluateStar_city_EvaId",
                table: "evaluateStar");

            migrationBuilder.DropForeignKey(
                name: "FK_hotel_city_CityId",
                table: "hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_restaurant_city_CityId",
                table: "restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_tourguide_city_CityId",
                table: "tourguide");

            migrationBuilder.DropIndex(
                name: "IX_tourguide_CityId",
                table: "tourguide");

            migrationBuilder.DropIndex(
                name: "IX_restaurant_CityId",
                table: "restaurant");

            migrationBuilder.DropIndex(
                name: "IX_hotel_CityId",
                table: "hotel");

            migrationBuilder.DropIndex(
                name: "IX_evaluateStar_EvaId",
                table: "evaluateStar");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_EvaId",
                table: "evaluate");
        }
    }
}

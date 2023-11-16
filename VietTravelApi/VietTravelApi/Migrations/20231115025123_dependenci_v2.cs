using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class dependenci_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_tour_city_CityId",
                table: "tour");

            migrationBuilder.DropForeignKey(
                name: "FK_tourguide_city_CityId",
                table: "tourguide");

            migrationBuilder.DropIndex(
                name: "IX_evaluateStar_EvaId",
                table: "evaluateStar");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_EvaId",
                table: "evaluate");

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "evaluateStar",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HotelId",
                table: "evaluateStar",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RestaurantId",
                table: "evaluateStar",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TourId",
                table: "evaluateStar",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "evaluate",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HotelId",
                table: "evaluate",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RestaurantId",
                table: "evaluate",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TourId",
                table: "evaluate",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tourpackage_HotelId",
                table: "tourpackage",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_tourpackage_RestaurantId",
                table: "tourpackage",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_tourpackage_TimePackageId",
                table: "tourpackage",
                column: "TimePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_tourpackage_TourId",
                table: "tourpackage",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_TourPackageId",
                table: "ticket",
                column: "TourPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_UserId",
                table: "ticket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TourId",
                table: "Schedule",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_event_TourId",
                table: "event",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluateStar_CityId",
                table: "evaluateStar",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluateStar_HotelId",
                table: "evaluateStar",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluateStar_RestaurantId",
                table: "evaluateStar",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluateStar_TourId",
                table: "evaluateStar",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluateStar_UserId",
                table: "evaluateStar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_CityId",
                table: "evaluate",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_HotelId",
                table: "evaluate",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_RestaurantId",
                table: "evaluate",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_TourId",
                table: "evaluate",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_UserId",
                table: "evaluate",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_evaluate_city_CityId",
                table: "evaluate",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluate_hotel_HotelId",
                table: "evaluate",
                column: "HotelId",
                principalTable: "hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluate_restaurant_RestaurantId",
                table: "evaluate",
                column: "RestaurantId",
                principalTable: "restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluate_tour_TourId",
                table: "evaluate",
                column: "TourId",
                principalTable: "tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluate_user_UserId",
                table: "evaluate",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluateStar_city_CityId",
                table: "evaluateStar",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluateStar_hotel_HotelId",
                table: "evaluateStar",
                column: "HotelId",
                principalTable: "hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluateStar_restaurant_RestaurantId",
                table: "evaluateStar",
                column: "RestaurantId",
                principalTable: "restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluateStar_tour_TourId",
                table: "evaluateStar",
                column: "TourId",
                principalTable: "tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluateStar_user_UserId",
                table: "evaluateStar",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_event_tour_TourId",
                table: "event",
                column: "TourId",
                principalTable: "tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_city_CityId",
                table: "hotel",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_restaurant_city_CityId",
                table: "restaurant",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_tour_TourId",
                table: "Schedule",
                column: "TourId",
                principalTable: "tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_tourpackage_TourPackageId",
                table: "ticket",
                column: "TourPackageId",
                principalTable: "tourpackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_user_UserId",
                table: "ticket",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tour_city_CityId",
                table: "tour",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tourguide_city_CityId",
                table: "tourguide",
                column: "CityId",
                principalTable: "city",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tourpackage_hotel_HotelId",
                table: "tourpackage",
                column: "HotelId",
                principalTable: "hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tourpackage_restaurant_RestaurantId",
                table: "tourpackage",
                column: "RestaurantId",
                principalTable: "restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tourpackage_timepackage_TimePackageId",
                table: "tourpackage",
                column: "TimePackageId",
                principalTable: "timepackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tourpackage_tour_TourId",
                table: "tourpackage",
                column: "TourId",
                principalTable: "tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_city_CityId",
                table: "evaluate");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_hotel_HotelId",
                table: "evaluate");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_restaurant_RestaurantId",
                table: "evaluate");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_tour_TourId",
                table: "evaluate");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluate_user_UserId",
                table: "evaluate");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluateStar_city_CityId",
                table: "evaluateStar");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluateStar_hotel_HotelId",
                table: "evaluateStar");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluateStar_restaurant_RestaurantId",
                table: "evaluateStar");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluateStar_tour_TourId",
                table: "evaluateStar");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluateStar_user_UserId",
                table: "evaluateStar");

            migrationBuilder.DropForeignKey(
                name: "FK_event_tour_TourId",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_hotel_city_CityId",
                table: "hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_restaurant_city_CityId",
                table: "restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_tour_TourId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_tourpackage_TourPackageId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_user_UserId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_tour_city_CityId",
                table: "tour");

            migrationBuilder.DropForeignKey(
                name: "FK_tourguide_city_CityId",
                table: "tourguide");

            migrationBuilder.DropForeignKey(
                name: "FK_tourpackage_hotel_HotelId",
                table: "tourpackage");

            migrationBuilder.DropForeignKey(
                name: "FK_tourpackage_restaurant_RestaurantId",
                table: "tourpackage");

            migrationBuilder.DropForeignKey(
                name: "FK_tourpackage_timepackage_TimePackageId",
                table: "tourpackage");

            migrationBuilder.DropForeignKey(
                name: "FK_tourpackage_tour_TourId",
                table: "tourpackage");

            migrationBuilder.DropIndex(
                name: "IX_tourpackage_HotelId",
                table: "tourpackage");

            migrationBuilder.DropIndex(
                name: "IX_tourpackage_RestaurantId",
                table: "tourpackage");

            migrationBuilder.DropIndex(
                name: "IX_tourpackage_TimePackageId",
                table: "tourpackage");

            migrationBuilder.DropIndex(
                name: "IX_tourpackage_TourId",
                table: "tourpackage");

            migrationBuilder.DropIndex(
                name: "IX_ticket_TourPackageId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_UserId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TourId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_event_TourId",
                table: "event");

            migrationBuilder.DropIndex(
                name: "IX_evaluateStar_CityId",
                table: "evaluateStar");

            migrationBuilder.DropIndex(
                name: "IX_evaluateStar_HotelId",
                table: "evaluateStar");

            migrationBuilder.DropIndex(
                name: "IX_evaluateStar_RestaurantId",
                table: "evaluateStar");

            migrationBuilder.DropIndex(
                name: "IX_evaluateStar_TourId",
                table: "evaluateStar");

            migrationBuilder.DropIndex(
                name: "IX_evaluateStar_UserId",
                table: "evaluateStar");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_CityId",
                table: "evaluate");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_HotelId",
                table: "evaluate");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_RestaurantId",
                table: "evaluate");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_TourId",
                table: "evaluate");

            migrationBuilder.DropIndex(
                name: "IX_evaluate_UserId",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "evaluateStar");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "evaluateStar");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "evaluateStar");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "evaluateStar");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "evaluate");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "evaluate");

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
                name: "FK_tour_city_CityId",
                table: "tour",
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
    }
}

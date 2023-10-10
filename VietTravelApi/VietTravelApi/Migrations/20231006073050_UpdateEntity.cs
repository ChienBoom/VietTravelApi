using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class UpdateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_tourpackage_TourPackageId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_tourpackage_hotel_HotelId",
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
                name: "IX_tourpackage_TimePackageId",
                table: "tourpackage");

            migrationBuilder.DropIndex(
                name: "IX_tourpackage_TourId",
                table: "tourpackage");

            migrationBuilder.DropIndex(
                name: "IX_ticket_TourPackageId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "tourpackage");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "tourpackage",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "tourpackage",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<decimal>(
                name: "LastPrice",
                table: "tourpackage",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "tourpackage");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "tourpackage");

            migrationBuilder.DropColumn(
                name: "LastPrice",
                table: "tourpackage");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "tourpackage",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_tourpackage_HotelId",
                table: "tourpackage",
                column: "HotelId");

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
                column: "TourPackageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_tourpackage_TourPackageId",
                table: "ticket",
                column: "TourPackageId",
                principalTable: "tourpackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tourpackage_hotel_HotelId",
                table: "tourpackage",
                column: "HotelId",
                principalTable: "hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tourpackage_timepackage_TimePackageId",
                table: "tourpackage",
                column: "TimePackageId",
                principalTable: "timepackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tourpackage_tour_TourId",
                table: "tourpackage",
                column: "TourId",
                principalTable: "tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

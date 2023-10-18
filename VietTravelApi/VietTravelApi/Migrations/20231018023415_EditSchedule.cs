using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class EditSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TourPackageId",
                table: "Schedule");

            migrationBuilder.AddColumn<string>(
                name: "ListScheduleTourPackage",
                table: "tourpackage",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TourId",
                table: "Schedule",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListScheduleTourPackage",
                table: "tourpackage");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Schedule");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Schedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Schedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "TourPackageId",
                table: "Schedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Pictures = table.Column<string>(maxLength: 1000, nullable: false),
                    TitleIntroduct = table.Column<string>(maxLength: 2000, nullable: false),
                    ContentIntroduct = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tourpackage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tourpackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 25, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Role = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tour",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Pictures = table.Column<string>(maxLength: 1000, nullable: false),
                    TitleIntroduct = table.Column<string>(maxLength: 2000, nullable: false),
                    ContentIntroduct = table.Column<string>(maxLength: 2000, nullable: false),
                    CityId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tour_city_CityId",
                        column: x => x.CityId,
                        principalTable: "city",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "evaluate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(maxLength: 2000, nullable: false),
                    DateOfEvaluate = table.Column<DateTime>(nullable: false),
                    NumberOfInteractions = table.Column<int>(nullable: false),
                    MediumStar = table.Column<float>(nullable: false),
                    TourId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evaluate_tour_TourId",
                        column: x => x.TourId,
                        principalTable: "tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_evaluate_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    TourId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotel_tour_TourId",
                        column: x => x.TourId,
                        principalTable: "tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tour_toupackage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<long>(nullable: false),
                    TourPackageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tour_toupackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tour_toupackage_tour_TourId",
                        column: x => x.TourId,
                        principalTable: "tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tour_toupackage_tourpackage_TourPackageId",
                        column: x => x.TourPackageId,
                        principalTable: "tourpackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket_detail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDay = table.Column<DateTime>(nullable: false),
                    EndDay = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    HotelId = table.Column<long>(nullable: false),
                    TourPackageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_detail_hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_detail_tourpackage_TourPackageId",
                        column: x => x.TourPackageId,
                        principalTable: "tourpackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TicketDetailId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_ticket_detail_TicketDetailId",
                        column: x => x.TicketDetailId,
                        principalTable: "ticket_detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    TourId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    TicketDetailId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_ticket_detail_TicketDetailId",
                        column: x => x.TicketDetailId,
                        principalTable: "ticket_detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_tour_TourId",
                        column: x => x.TourId,
                        principalTable: "tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tourguide",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Sex = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    TourId = table.Column<long>(nullable: false),
                    TicketDetailId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tourguide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tourguide_ticket_detail_TicketDetailId",
                        column: x => x.TicketDetailId,
                        principalTable: "ticket_detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tourguide_tour_TourId",
                        column: x => x.TourId,
                        principalTable: "tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_TourId",
                table: "evaluate",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluate_UserId",
                table: "evaluate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_TourId",
                table: "hotel",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TicketDetailId",
                table: "Schedule",
                column: "TicketDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_TicketDetailId",
                table: "ticket",
                column: "TicketDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_TourId",
                table: "ticket",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_UserId",
                table: "ticket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_detail_HotelId",
                table: "ticket_detail",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_detail_TourPackageId",
                table: "ticket_detail",
                column: "TourPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_tour_CityId",
                table: "tour",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tour_toupackage_TourId",
                table: "tour_toupackage",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_tour_toupackage_TourPackageId",
                table: "tour_toupackage",
                column: "TourPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_tourguide_TicketDetailId",
                table: "tourguide",
                column: "TicketDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tourguide_TourId",
                table: "tourguide",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evaluate");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "tour_toupackage");

            migrationBuilder.DropTable(
                name: "tourguide");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "ticket_detail");

            migrationBuilder.DropTable(
                name: "hotel");

            migrationBuilder.DropTable(
                name: "tourpackage");

            migrationBuilder.DropTable(
                name: "tour");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}

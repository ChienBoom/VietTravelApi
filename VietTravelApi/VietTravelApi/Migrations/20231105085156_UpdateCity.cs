using Microsoft.EntityFrameworkCore.Migrations;

namespace VietTravelApi.Migrations
{
    public partial class UpdateCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "city",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "city");
        }
    }
}

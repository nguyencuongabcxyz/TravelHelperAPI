using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelperProject.Migrations
{
    public partial class AddIsExpired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "PublicTrips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AvatarLocation",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "PublicTrips");

            migrationBuilder.DropColumn(
                name: "AvatarLocation",
                table: "AspNetUsers");
        }
    }
}

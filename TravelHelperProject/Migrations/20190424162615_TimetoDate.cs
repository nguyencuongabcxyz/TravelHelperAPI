using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelperProject.Migrations
{
    public partial class TimetoDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "TravelRequests",
                newName: "DepartureDate");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "TravelRequests",
                newName: "ArrivalDate");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "HostOffers",
                newName: "DepartureDate");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "HostOffers",
                newName: "ArrivalDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FriendRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "TravelRequests",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "TravelRequests",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "HostOffers",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "HostOffers",
                newName: "ArrivalTime");
        }
    }
}

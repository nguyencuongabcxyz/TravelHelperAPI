using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelperProject.Migrations
{
    public partial class AddPhotoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Photos");
        }
    }
}

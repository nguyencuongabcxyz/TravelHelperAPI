using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelperProject.Migrations
{
    public partial class ChangeDataTypeOfCountryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Country",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

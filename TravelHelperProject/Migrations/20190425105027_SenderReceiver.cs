using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelperProject.Migrations
{
    public partial class SenderReceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_AspNetUsers_HostId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_AspNetUsers_TravelerId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReporterId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ViolatorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelRequests_AspNetUsers_HostId",
                table: "TravelRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelRequests_AspNetUsers_TravelerId",
                table: "TravelRequests");

            migrationBuilder.RenameColumn(
                name: "TravelerId",
                table: "TravelRequests",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "TravelRequests",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelRequests_TravelerId",
                table: "TravelRequests",
                newName: "IX_TravelRequests_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelRequests_HostId",
                table: "TravelRequests",
                newName: "IX_TravelRequests_ReceiverId");

            migrationBuilder.RenameColumn(
                name: "ViolatorId",
                table: "Reports",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "ReporterId",
                table: "Reports",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ViolatorId",
                table: "Reports",
                newName: "IX_Reports_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReporterId",
                table: "Reports",
                newName: "IX_Reports_ReceiverId");

            migrationBuilder.RenameColumn(
                name: "TravelerId",
                table: "HostOffers",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "HostId",
                table: "HostOffers",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_HostOffers_TravelerId",
                table: "HostOffers",
                newName: "IX_HostOffers_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_HostOffers_HostId",
                table: "HostOffers",
                newName: "IX_HostOffers_ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_HostOffers_AspNetUsers_ReceiverId",
                table: "HostOffers",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HostOffers_AspNetUsers_SenderId",
                table: "HostOffers",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReceiverId",
                table: "Reports",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_SenderId",
                table: "Reports",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRequests_AspNetUsers_ReceiverId",
                table: "TravelRequests",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRequests_AspNetUsers_SenderId",
                table: "TravelRequests",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_AspNetUsers_ReceiverId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_AspNetUsers_SenderId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReceiverId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_SenderId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelRequests_AspNetUsers_ReceiverId",
                table: "TravelRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelRequests_AspNetUsers_SenderId",
                table: "TravelRequests");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "TravelRequests",
                newName: "TravelerId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "TravelRequests",
                newName: "HostId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelRequests_SenderId",
                table: "TravelRequests",
                newName: "IX_TravelRequests_TravelerId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelRequests_ReceiverId",
                table: "TravelRequests",
                newName: "IX_TravelRequests_HostId");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Reports",
                newName: "ViolatorId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Reports",
                newName: "ReporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_SenderId",
                table: "Reports",
                newName: "IX_Reports_ViolatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReceiverId",
                table: "Reports",
                newName: "IX_Reports_ReporterId");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "HostOffers",
                newName: "TravelerId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "HostOffers",
                newName: "HostId");

            migrationBuilder.RenameIndex(
                name: "IX_HostOffers_SenderId",
                table: "HostOffers",
                newName: "IX_HostOffers_TravelerId");

            migrationBuilder.RenameIndex(
                name: "IX_HostOffers_ReceiverId",
                table: "HostOffers",
                newName: "IX_HostOffers_HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_HostOffers_AspNetUsers_HostId",
                table: "HostOffers",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HostOffers_AspNetUsers_TravelerId",
                table: "HostOffers",
                column: "TravelerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReporterId",
                table: "Reports",
                column: "ReporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ViolatorId",
                table: "Reports",
                column: "ViolatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRequests_AspNetUsers_HostId",
                table: "TravelRequests",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRequests_AspNetUsers_TravelerId",
                table: "TravelRequests",
                column: "TravelerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

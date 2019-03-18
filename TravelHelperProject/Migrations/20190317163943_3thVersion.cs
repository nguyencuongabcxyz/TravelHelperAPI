using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHelperProject.Migrations
{
    public partial class _3thVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_ReceiverUserId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_Users_SenderUserId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_User1UserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_User2UserId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Users_UserId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_Users_HostUserId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_Users_TravelerUserId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicTrips_Users_UserId",
                table: "PublicTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_References_Users_ReceiverUserId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_References_Users_SenderUserId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ReporterUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ViolatorUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelRequests_Users_HostUserId",
                table: "TravelRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelRequests_Users_TravelerUserId",
                table: "TravelRequests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TravelRequests_HostUserId",
                table: "TravelRequests");

            migrationBuilder.DropIndex(
                name: "IX_TravelRequests_TravelerUserId",
                table: "TravelRequests");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReporterUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ViolatorUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_References_ReceiverUserId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_SenderUserId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_PublicTrips_UserId",
                table: "PublicTrips");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_HostOffers_HostUserId",
                table: "HostOffers");

            migrationBuilder.DropIndex(
                name: "IX_HostOffers_TravelerUserId",
                table: "HostOffers");

            migrationBuilder.DropIndex(
                name: "IX_Homes_UserId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Friends_User1UserId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_User2UserId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_ReceiverUserId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_SenderUserId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "HostUserId",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "TravelerUserId",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "ReporterUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ViolatorUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "SenderUserId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PublicTrips");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "HostUserId",
                table: "HostOffers");

            migrationBuilder.DropColumn(
                name: "TravelerUserId",
                table: "HostOffers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "User1UserId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "User2UserId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "SenderUserId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "HostId",
                table: "TravelRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravelerId",
                table: "TravelRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViolatorId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "References",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "References",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PublicTrips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostId",
                table: "HostOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravelerId",
                table: "HostOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Homes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser1Id",
                table: "Friends",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser2Id",
                table: "Friends",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "FriendRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "FriendRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Occupation = table.Column<string>(nullable: true),
                    FluentLanguage = table.Column<string>(nullable: true),
                    LearningLanguage = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Interest = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserProfileId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelRequests_HostId",
                table: "TravelRequests",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelRequests_TravelerId",
                table: "TravelRequests",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReporterId",
                table: "Reports",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ViolatorId",
                table: "Reports",
                column: "ViolatorId");

            migrationBuilder.CreateIndex(
                name: "IX_References_ReceiverId",
                table: "References",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_References_SenderId",
                table: "References",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicTrips_ApplicationUserId",
                table: "PublicTrips",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ApplicationUserId",
                table: "Photos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_HostOffers_HostId",
                table: "HostOffers",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_HostOffers_TravelerId",
                table: "HostOffers",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_ApplicationUserId",
                table: "Homes",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_ApplicationUser1Id",
                table: "Friends",
                column: "ApplicationUser1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_ApplicationUser2Id",
                table: "Friends",
                column: "ApplicationUser2Id");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ApplicationUserId",
                table: "UserProfiles",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_SenderId",
                table: "FriendRequests",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_ApplicationUser1Id",
                table: "Friends",
                column: "ApplicationUser1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_ApplicationUser2Id",
                table: "Friends",
                column: "ApplicationUser2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_AspNetUsers_ApplicationUserId",
                table: "Homes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_ApplicationUserId",
                table: "Photos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicTrips_AspNetUsers_ApplicationUserId",
                table: "PublicTrips",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_References_AspNetUsers_ReceiverId",
                table: "References",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_References_AspNetUsers_SenderId",
                table: "References",
                column: "SenderId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_ReceiverId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_SenderId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_ApplicationUser1Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_ApplicationUser2Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Homes_AspNetUsers_ApplicationUserId",
                table: "Homes");

            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_AspNetUsers_HostId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_HostOffers_AspNetUsers_TravelerId",
                table: "HostOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_ApplicationUserId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicTrips_AspNetUsers_ApplicationUserId",
                table: "PublicTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_References_AspNetUsers_ReceiverId",
                table: "References");

            migrationBuilder.DropForeignKey(
                name: "FK_References_AspNetUsers_SenderId",
                table: "References");

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

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_TravelRequests_HostId",
                table: "TravelRequests");

            migrationBuilder.DropIndex(
                name: "IX_TravelRequests_TravelerId",
                table: "TravelRequests");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReporterId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ViolatorId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_References_ReceiverId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_References_SenderId",
                table: "References");

            migrationBuilder.DropIndex(
                name: "IX_PublicTrips_ApplicationUserId",
                table: "PublicTrips");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ApplicationUserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_HostOffers_HostId",
                table: "HostOffers");

            migrationBuilder.DropIndex(
                name: "IX_HostOffers_TravelerId",
                table: "HostOffers");

            migrationBuilder.DropIndex(
                name: "IX_Homes_ApplicationUserId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Friends_ApplicationUser1Id",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_ApplicationUser2Id",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "TravelerId",
                table: "TravelRequests");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ViolatorId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PublicTrips");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "HostOffers");

            migrationBuilder.DropColumn(
                name: "TravelerId",
                table: "HostOffers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "ApplicationUser1Id",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "ApplicationUser2Id",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "HostUserId",
                table: "TravelRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TravelerUserId",
                table: "TravelRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReporterUserId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViolatorUserId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "References",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderUserId",
                table: "References",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PublicTrips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Photos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderUserId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HostUserId",
                table: "HostOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TravelerUserId",
                table: "HostOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Homes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User1UserId",
                table: "Friends",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User2UserId",
                table: "Friends",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverUserId",
                table: "FriendRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderUserId",
                table: "FriendRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    About = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    FluentLanguage = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    Interest = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    LearningLanguage = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelRequests_HostUserId",
                table: "TravelRequests",
                column: "HostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelRequests_TravelerUserId",
                table: "TravelRequests",
                column: "TravelerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReporterUserId",
                table: "Reports",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ViolatorUserId",
                table: "Reports",
                column: "ViolatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_References_ReceiverUserId",
                table: "References",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_References_SenderUserId",
                table: "References",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicTrips_UserId",
                table: "PublicTrips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverUserId",
                table: "Messages",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUserId",
                table: "Messages",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HostOffers_HostUserId",
                table: "HostOffers",
                column: "HostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HostOffers_TravelerUserId",
                table: "HostOffers",
                column: "TravelerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_UserId",
                table: "Homes",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_User1UserId",
                table: "Friends",
                column: "User1UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_User2UserId",
                table: "Friends",
                column: "User2UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverUserId",
                table: "FriendRequests",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderUserId",
                table: "FriendRequests",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_ReceiverUserId",
                table: "FriendRequests",
                column: "ReceiverUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_Users_SenderUserId",
                table: "FriendRequests",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_User1UserId",
                table: "Friends",
                column: "User1UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_User2UserId",
                table: "Friends",
                column: "User2UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Users_UserId",
                table: "Homes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HostOffers_Users_HostUserId",
                table: "HostOffers",
                column: "HostUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HostOffers_Users_TravelerUserId",
                table: "HostOffers",
                column: "TravelerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverUserId",
                table: "Messages",
                column: "ReceiverUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderUserId",
                table: "Messages",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicTrips_Users_UserId",
                table: "PublicTrips",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_References_Users_ReceiverUserId",
                table: "References",
                column: "ReceiverUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_References_Users_SenderUserId",
                table: "References",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ReporterUserId",
                table: "Reports",
                column: "ReporterUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ViolatorUserId",
                table: "Reports",
                column: "ViolatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRequests_Users_HostUserId",
                table: "TravelRequests",
                column: "HostUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelRequests_Users_TravelerUserId",
                table: "TravelRequests",
                column: "TravelerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

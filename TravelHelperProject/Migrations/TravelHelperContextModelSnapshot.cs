﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelHelperProject.Models;

namespace TravelHelperProject.Migrations
{
    [DbContext(typeof(TravelHelperContext))]
    partial class TravelHelperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TravelHelperProject.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<string>("Other");

                    b.Property<string>("Skype");

                    b.Property<string>("Twitter");

                    b.Property<string>("WhatsApp");

                    b.HasKey("ContactId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Friend", b =>
                {
                    b.Property<int>("FriendId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUser1Id");

                    b.Property<string>("ApplicationUser2Id");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<bool?>("IsDeleted");

                    b.HasKey("FriendId");

                    b.HasIndex("ApplicationUser1Id");

                    b.HasIndex("ApplicationUser2Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("TravelHelperProject.Models.FriendRequest", b =>
                {
                    b.Property<int>("FriendRequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<bool?>("IsAccepted");

                    b.Property<string>("Message");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.HasKey("FriendRequestId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Home", b =>
                {
                    b.Property<int>("HomeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionInfo");

                    b.Property<string>("AllowedThing");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("MaxGuest");

                    b.Property<string>("PreferedGender");

                    b.Property<string>("SleepingArrangement");

                    b.Property<string>("SleepingDescription");

                    b.Property<string>("Stuff");

                    b.Property<string>("TransportationAccess");

                    b.HasKey("HomeId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("TravelHelperProject.Models.HostOffer", b =>
                {
                    b.Property<int>("HostOfferId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<string>("HostId");

                    b.Property<bool?>("IsAccepted");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Message");

                    b.Property<string>("TravelerId");

                    b.Property<int?>("TravelerNumber");

                    b.HasKey("HostOfferId");

                    b.HasIndex("HostId");

                    b.HasIndex("TravelerId");

                    b.ToTable("HostOffers");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Descripton");

                    b.Property<bool?>("IsAvatar");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Location");

                    b.HasKey("PhotoId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("TravelHelperProject.Models.PublicTrip", b =>
                {
                    b.Property<int>("PublicTripId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<DateTime?>("ArrivalDate");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("DepartureDate");

                    b.Property<string>("Description");

                    b.Property<string>("Destination");

                    b.Property<bool?>("IsDeleted");

                    b.Property<bool>("IsExpired");

                    b.Property<int?>("TravelerNumber");

                    b.HasKey("PublicTripId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("PublicTrips");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Reference", b =>
                {
                    b.Property<int>("ReferenceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("ReceiverId");

                    b.Property<string>("SenderId");

                    b.Property<bool?>("Status");

                    b.HasKey("ReferenceId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("References");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<bool?>("IsDeleted");

                    b.Property<bool?>("IsSolved");

                    b.Property<string>("Message");

                    b.Property<string>("ReporterId");

                    b.Property<string>("Type");

                    b.Property<string>("ViolatorId");

                    b.HasKey("ReportId");

                    b.HasIndex("ReporterId");

                    b.HasIndex("ViolatorId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("TravelHelperProject.Models.TravelRequest", b =>
                {
                    b.Property<int>("TravelRequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ArrivalTime");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("DepartureTime");

                    b.Property<string>("HostId");

                    b.Property<bool?>("IsAccepted");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("Message");

                    b.Property<string>("TravelerId");

                    b.Property<int?>("TravelerNumber");

                    b.HasKey("TravelRequestId");

                    b.HasIndex("HostId");

                    b.HasIndex("TravelerId");

                    b.ToTable("TravelRequests");
                });

            modelBuilder.Entity("TravelHelperProject.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("About");

                    b.Property<string>("Address");

                    b.Property<string>("AvatarLocation");

                    b.Property<DateTime?>("Birthday");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("FluentLanguage");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool?>("Gender");

                    b.Property<string>("Interest");

                    b.Property<bool?>("IsActive");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("LearningLanguage");

                    b.Property<string>("Occupation");

                    b.Property<bool?>("Status");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelHelperProject.Models.City", b =>
                {
                    b.HasOne("TravelHelperProject.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelHelperProject.Models.Contact", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Contact")
                        .HasForeignKey("TravelHelperProject.Models.Contact", "ApplicationUserId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Friend", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "ApplicationUser1")
                        .WithMany("FriendsUser1")
                        .HasForeignKey("ApplicationUser1Id");

                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "ApplicationUser2")
                        .WithMany("FriendsUser2")
                        .HasForeignKey("ApplicationUser2Id");
                });

            modelBuilder.Entity("TravelHelperProject.Models.FriendRequest", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Receiver")
                        .WithMany("FriendRequestsReceived")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Sender")
                        .WithMany("FriendRequestsSent")
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Home", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Home")
                        .HasForeignKey("TravelHelperProject.Models.Home", "ApplicationUserId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.HostOffer", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Host")
                        .WithMany("HostOffersSent")
                        .HasForeignKey("HostId");

                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Traveler")
                        .WithMany("HostOfferReceived")
                        .HasForeignKey("TravelerId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Message", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Receiver")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Photo", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "User")
                        .WithMany("Photos")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.PublicTrip", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "User")
                        .WithMany("PublicTrips")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Reference", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Receiver")
                        .WithMany("ReferenceReceived")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Sender")
                        .WithMany("ReferencesSent")
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.Report", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Reporter")
                        .WithMany("ReportsSent")
                        .HasForeignKey("ReporterId");

                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Violator")
                        .WithMany("ReportsReceived")
                        .HasForeignKey("ViolatorId");
                });

            modelBuilder.Entity("TravelHelperProject.Models.TravelRequest", b =>
                {
                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Host")
                        .WithMany("TravelRequestsReceived")
                        .HasForeignKey("HostId");

                    b.HasOne("TravelHelperProject.Models.ApplicationUser", "Traveler")
                        .WithMany("TravelRequestsSent")
                        .HasForeignKey("TravelerId");
                });
#pragma warning restore 612, 618
        }
    }
}

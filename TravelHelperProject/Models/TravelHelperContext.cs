using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class TravelHelperContext: IdentityDbContext
    {
        public TravelHelperContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HostOffer> HostOffers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PublicTrip> PublicTrips { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<TravelRequest> TravelRequests { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


    }
}

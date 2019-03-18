using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public UserProfile UserProfile { get; set; }
        public Contact Contact { get; set; }
        public Home Home { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<PublicTrip> PublicTrips { get; set; }

        [InverseProperty("Host")]
        public ICollection<HostOffer> HostOffersSent { get; set; }
        [InverseProperty("Traveler")]
        public ICollection<HostOffer> HostOfferReceived { get; set; }
        [InverseProperty("Sender")]
        public ICollection<Reference> ReferencesSent { get; set; }
        [InverseProperty("Receiver")]
        public ICollection<Reference> ReferenceReceived { get; set; }
        [InverseProperty("Reporter")]
        public ICollection<Report> ReportsSent { get; set; }
        [InverseProperty("Violator")]
        public ICollection<Report> ReportsReceived { get; set; }
        [InverseProperty("Traveler")]
        public ICollection<TravelRequest> TravelRequestsSent { get; set; }
        [InverseProperty("Host")]
        public ICollection<TravelRequest> TravelRequestsReceived { get; set; }

        [InverseProperty("Sender")]
        public ICollection<Message> MessagesSent { get; set; }
        [InverseProperty("Receiver")]
        public ICollection<Message> MessagesReceived { get; set; }
        [InverseProperty("Sender")]
        public ICollection<FriendRequest> FriendRequestsSent { get; set; }
        [InverseProperty("Receiver")]
        public ICollection<FriendRequest> FriendRequestsReceived { get; set; }
        [InverseProperty("ApplicationUser1")]
        public ICollection<Friend> FriendsUser1 { get; set; }
        [InverseProperty("ApplicationUser2")]
        public ICollection<Friend> FriendsUser2 { get; set; }
    }
}

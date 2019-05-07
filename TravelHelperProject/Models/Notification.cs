using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationType Type { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public enum NotificationType
    {
        TravelRequest,
        HostOffer,
        FriendRequest,
        Reference
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class Friend
    {
        public int FriendId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public ApplicationUser ApplicationUser1 { get; set; }
        public ApplicationUser ApplicationUser2 { get; set; }
    }
}

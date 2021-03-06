﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class FriendRequest
    {
        public int FriendRequestId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Message { get; set; }
        public bool? IsAccepted { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsCanceled { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
    }
}

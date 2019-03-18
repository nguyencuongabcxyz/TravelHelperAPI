﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class HostOffer
    {
        public int HostOfferId { get; set; }
        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime { get; set; }
        public int? TravelerNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsAccepted { get; set; }
        public bool? IsDeleted { get; set; }

        public ApplicationUser Host { get; set; }
        public ApplicationUser Traveler { get; set; }
    }
}

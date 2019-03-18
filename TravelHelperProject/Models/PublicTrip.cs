using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class PublicTrip
    {
        public int PublicTripId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public int? TravelerNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsDeleted { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}

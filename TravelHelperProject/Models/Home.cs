using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class Home
    {
        public int HomeId { get; set; }
        public int? MaxGuest { get; set; }
        public string PreferedGender { get; set; }
        public string SleepingArrangement { get; set; }
        public string SleepingDescription { get; set; }
        public string TransportationAccess { get; set; }
        public string AllowedThing { get; set; }
        public string Stuff { get; set; }
        public string AdditionInfo { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}

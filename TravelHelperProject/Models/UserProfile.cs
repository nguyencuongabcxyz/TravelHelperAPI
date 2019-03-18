using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Models
{
    public class UserProfile
    {

        public int UserProfileId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Occupation { get; set; }
        public string FluentLanguage { get; set; }
        public string LearningLanguage { get; set; }
        public string About { get; set; }
        public string Interest { get; set; }
        public bool? Status { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //public UserAccount UserAccount { get; set; }

    }
}

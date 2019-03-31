using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.ViewModels
{
    public class ProfileViewModel
    {
        //user.FullName = applicationUser.FullName;
        //    user.Address = applicationUser.Address;
        //    user.Gender = applicationUser.Gender;
        //    user.Birthday = applicationUser.Birthday;
        //    user.Occupation = applicationUser.Occupation;
        //    user.FluentLanguage = applicationUser.FluentLanguage;
        //    user.LearningLanguage = applicationUser.LearningLanguage;
        //    user.About = applicationUser.About;
        //    user.Interest = applicationUser.Interest;
        //    user.Status = applicationUser.Status;
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Occupation { get; set; }
        public string FluentLanguage { get; set; }
        public string LearningLanguage { get; set; }
        public string About { get; set; }
        public string Interest { get; set; }
        public bool Status { get; set; }

    }
}

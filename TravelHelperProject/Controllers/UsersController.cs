using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Models;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private TravelHelperContext _TravelHelperContext;

        public UsersController(TravelHelperContext travelHelperContext)
        {
            this._TravelHelperContext = travelHelperContext;
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutUserProfile(string id, ApplicationUser applicationUser)
        {
            var user = this._TravelHelperContext.ApplicationUsers.Where(s => s.Id == id).FirstOrDefault();

            user.FullName = applicationUser.FullName;
            user.Address = applicationUser.Address;
            user.Gender = applicationUser.Gender;
            user.Birthday = applicationUser.Birthday;
            user.Occupation = applicationUser.Occupation;
            user.FluentLanguage = applicationUser.FluentLanguage;
            user.LearningLanguage = applicationUser.LearningLanguage;
            user.About = applicationUser.About;
            user.Interest = applicationUser.Interest;
            user.Status = applicationUser.Status;
            this._TravelHelperContext.SaveChanges();
            return Ok(applicationUser);
        }
    }
}
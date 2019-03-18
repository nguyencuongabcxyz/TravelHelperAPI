using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelHelperProject.Models;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private TravelHelperContext _travelHelperContext;
        public UsersController(TravelHelperContext travelHelperContext)
        {
            this._travelHelperContext = travelHelperContext;
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutUserProfile(string id, ApplicationUser applicationUser)
        {
            Console.Write(1234);
            var user = _travelHelperContext.ApplicationUsers.Where(s => s.Id == id).FirstOrDefault();
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
            
            this._travelHelperContext.SaveChanges();
            return Ok(applicationUser);
        }
    }
}
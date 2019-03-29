using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using TravelHelperProject.Models;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {

        private TravelHelperContext _TravelHelperContext;

        public UsersController(TravelHelperContext travelHelperContext)
        {
            this._TravelHelperContext = travelHelperContext;
        }
        //Untested 
        //GET api/Users
        [HttpGet]
        public IActionResult GetUserProfile()
        {
            string userId;
            try
            {
                userId = User.Claims.First(c => c.Type == "UserID").Value;
            }
            catch
            {
                return Unauthorized();
            }
            var user = _TravelHelperContext.ApplicationUsers.Where(s => s.Id == userId)
                .Include("PublicTrips")
                .Include(s => s.Photos)
                .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
        //Untested
        //GET api/User/id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserProfile(string id)
        {
            var user = _TravelHelperContext.ApplicationUsers.Where(s => s.Id == id)
                .Include(s => s.PublicTrips).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
        //Tested 
        //PUT api/Users
        [HttpPut]
        public IActionResult PutUserProfile(ApplicationUser applicationUser)
        {
            string userId;
            try
            {
                userId = User.Claims.First(c => c.Type == "UserID").Value;
            }
            catch
            {
                return Unauthorized();
            }
            var user = this._TravelHelperContext.ApplicationUsers.Where(s => s.Id == userId).FirstOrDefault();

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
            //var user = _TravelHelperContext.ApplicationUsers.Where(s => s.Id == userId).FirstOrDefault();
            //applicationUser.Id = userId;
            //_TravelHelperContext.Entry(user).CurrentValues.SetValues(applicationUser);
            //_TravelHelperContext.SaveChanges();
            return Ok(user);

        }
        //Tested
        //GET api/Users/publictrips
        [HttpGet]
        [Route("PublicTrips")]
        public IActionResult GetUserPublicTrip()
        {
            string userId;
            try
            {
                userId = User.Claims.First(c => c.Type == "UserID").Value;
            }
            catch
            {
                return Unauthorized();
            }
            var publicTrips = this._TravelHelperContext.PublicTrips.Where(s => s.ApplicationUserId == userId && s.IsDeleted!=true)
                .Include(s => s.User).ToList();
            if (publicTrips.Count==0)
            {
                return NoContent();
            }
            return Ok(publicTrips);
        }
        //Tested
        //GET: api/Users/Search?address=address
        [HttpGet]
        [Route("Search")]
        public IActionResult GetUserByAddress(string address)
        {
            var users = this._TravelHelperContext.ApplicationUsers.Where(s => s.Address.Contains(address)).ToList();
        
            return Ok(users);
        }
    }
}
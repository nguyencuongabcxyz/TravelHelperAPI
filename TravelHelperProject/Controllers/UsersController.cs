using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using TravelHelperProject.Models;
using TravelHelperProject.Services;
using TravelHelperProject.ViewModels;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController( IUserService userService)
        {
            this._userService = userService;
        }
        //Untested 
        //GET api/Users
        [HttpGet]
        public IActionResult GetUserProfile()
        {
            string userId = GetUserId();
            if(userId == "error")
            {
                return Unauthorized();
            }
            string[] includes = { "PublicTrips", "Photos", "Home" };
            var user = _userService.GetSingleByCondition(s => s.Id == userId, includes);
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
            string[] includes = { "PublicTrips", "Photos", "Home" };
            var user = _userService.GetSingleByCondition(s => s.Id == id, includes);
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
        public IActionResult PutUserProfile(ProfileViewModel profile)
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var user = _userService.GetSingleByCondition(s => s.Id == userId, null);

            user.FullName = profile.FullName;
            user.Address = profile.Address;
            user.Gender = profile.Gender;
            user.Birthday = profile.Birthday;
            user.Occupation = profile.Occupation;
            user.FluentLanguage = profile.FluentLanguage;
            user.LearningLanguage = profile.LearningLanguage;
            user.About = profile.About;
            user.Interest = profile.Interest;
            user.Status = profile.Status;
            _userService.Update(user);
            _userService.SaveChanges();
            return Ok(user);

        }
        //Tested
        //GET: api/Users/Search?address=address
        [HttpGet]
        [Route("Search")]
        public IActionResult GetUserByAddress(string address)
        {
            var users = _userService.GetMultiByCondition(s => s.Address.Contains(address), null);
            return Ok(users);
        }

        //Untested
        //PUT: api/Users/Avatar? avatar = avatar
        [HttpPut]
        [Route("Avatar")]
        public IActionResult PutUserAvatar(string avatar)
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var user = _userService.GetSingleByCondition(s => s.Id == userId, null);
            user.AvatarLocation = avatar;
            return Ok();
        }
        [NonAction]
        public string GetUserId()
        {
            string userId;
            try
            {
                userId = User.Claims.First(c => c.Type == "UserID").Value;
            }
            catch
            {
                return "error";
            }
            return userId;
        }
    }
}
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
    public class UserProfileController : ControllerBase
    {
        private TravelHelperContext _travelHelperContext;
        public UserProfileController(TravelHelperContext travelHelperContext)
        {
            _travelHelperContext = travelHelperContext;
        }
        [HttpPost]
        public async Task PostUserProfile(UserProfile userProfile)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var profile = new UserProfile()
            {
                Name = userProfile.Name,
                Address = userProfile.Address,
            };
            await _travelHelperContext.UserProfiles.AddAsync(profile);
            await _travelHelperContext.SaveChangesAsync();
        }
        [HttpGet] 
        public IActionResult GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = _travelHelperContext.ApplicationUsers.Find(userId);
            _travelHelperContext.Entry(user).Reference(s => s.UserProfile).Load();
            return Ok(user.UserProfile);
        }
    }
}
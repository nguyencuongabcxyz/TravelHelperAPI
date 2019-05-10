using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Services;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendsController : ControllerBase
    {
        private IFriendService _friendService;
        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        [HttpGet]
        [Route("CheckIsFriend/{id}")]
        public IActionResult CheckIsFriend(string id)
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
            var friend = _friendService.GetSingleByCondition(s => ((s.ApplicationUser1.Id == userId && s.ApplicationUser2.Id == id) || (s.ApplicationUser2.Id == userId && s.ApplicationUser1.Id == id)) && s.IsDeleted != true, null);
            if(friend == null)
            {
                return Ok(new { isFriend = false });
            }
            else
            {
                return Ok(new { isFriend = true });
            }
        }
    }
}
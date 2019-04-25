using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Models;
using TravelHelperProject.Services;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendRequestsController : ControllerBase
    {
        private IFriendRequestService _friendRequestService;
        private IUserService _userService;
        private IFriendService _friendService;
        public FriendRequestsController(IFriendRequestService friendRequestService, IUserService userService, IFriendService friendService)
        {
            _friendRequestService = friendRequestService;
            _userService = userService;
            _friendService = friendService;
        }
        [HttpPost("{id}")]
        public IActionResult PostRequestFriend(FriendRequest friendRequest, string id)
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
            var sender = _userService.GetSingleByCondition(s => s.Id == userId, null);
            var receiver = _userService.GetSingleByCondition(s => s.Id == id, null);
            friendRequest.CreateDate = DateTime.Now;
            friendRequest.Sender = sender;
            friendRequest.Receiver = receiver;
            _friendRequestService.Add(friendRequest);
            _friendRequestService.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AcceptFriendRequest(int id)
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
            var receiver = _userService.GetSingleByCondition(s => s.Id == userId, null);
            var friendRequest = _friendRequestService.GetSingleByCondition(s => s.FriendRequestId == id, new string[] { "Sender" });
            var friend = new Friend()
            {
                ApplicationUser1 = friendRequest.Sender,
                ApplicationUser2 = receiver,
                CreateDate = DateTime.Now
            };
            if (friendRequest == null)
            {
                return NotFound();
            }
            if (receiver.Id != userId)
            {
                return NotFound();
            }
            friendRequest.IsAccepted = true;
            _friendService.Add(friend);
            _friendRequestService.SaveChanges();
            return Ok(friendRequest);
        }
        [HttpDelete("{id}")]
        public IActionResult IgnoreFriendRequest(int id)
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
            var friendRequest = _friendRequestService.GetSingleByCondition(s => s.FriendRequestId== id, new string[] { "Receiver" });
            if (friendRequest == null)
            {
                return NotFound();
            }
            if (friendRequest.Receiver.Id != userId)
            {
                return NotFound();
            }
            friendRequest.IsDeleted = true;
            _friendRequestService.SaveChanges();
            return NoContent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Services;
using TravelHelperProject.ViewModels;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserChatsController : ControllerBase
    {
        private IUserService _userSerivice;
        public UserChatsController(IUserService userService)
        {
            _userSerivice = userService;
        }
        [HttpGet("{id}")]
        public IActionResult GetUserChat(string id)
        {
            var user = _userSerivice.GetSingleByCondition(s => s.Id == id, null);
            var userModel = new UserChatViewModel()
            {
                FullName = user.FullName,
                Avatar = user.AvatarLocation
            };
            return Ok(userModel);
        }
    }
}
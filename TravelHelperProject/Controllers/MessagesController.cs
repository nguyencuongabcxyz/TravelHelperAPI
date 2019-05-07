using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Models;
using TravelHelperProject.Services;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private IUserService _userService;
        private IMessageService _messageService;
        public MessagesController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        [HttpPost("{id}")]
        public IActionResult PostMessage(string id, Message message)
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
            message.Sender = sender;
            message.Receiver = receiver;
            message.CreateDate = DateTime.Now;
            _messageService.Add(message);
            _messageService.SaveChanges();
            return Ok();
        }
    }
}
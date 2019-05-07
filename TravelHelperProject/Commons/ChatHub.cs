using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TravelHelperProject.Models;
using TravelHelperProject.Services;

namespace TravelHelperProject.Commons
{
    [Authorize]
    public class ChatHub: Hub
    {
        private IUserService _userService;
        private IMessageService _messageService;
        public ChatHub(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }
        public async void SendChatMessage(string to, string message)
        {
            var userId = Context.User.Claims.First(c => c.Type == "UserID").Value;
            var sender = _userService.GetSingleByCondition(s => s.Id == userId, null);
            var receiver = _userService.GetSingleByCondition(s => s.Id == to, null);
            var messageEntity = new Message()
            {
                Sender = sender,
                Receiver = receiver,
                CreateDate = DateTime.Now,
                Content = message
            };
            _messageService.Add(messageEntity);
            _messageService.SaveChanges();
            await Clients.Groups(userId).SendAsync("sendChatMessage",userId,message);
            await Clients.Groups(to).SendAsync("sendChatMessage", userId, message);
        }
        public override Task OnConnectedAsync()
        {
            var userId = Context.User.Claims.First(c => c.Type == "UserID").Value;
            Groups.AddToGroupAsync(Context.ConnectionId, userId);
            return base.OnConnectedAsync();
        }
    }
}

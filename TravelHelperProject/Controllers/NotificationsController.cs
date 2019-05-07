using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Models;
using TravelHelperProject.Services;
using TravelHelperProject.ViewModels;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private IUserService _userService;
        private INotificationService _notificationService;
        public NotificationsController(IUserService userService, INotificationService notificationService)
        {
            _userService = userService;
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult GetNotifications(int index)
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
            var notifications = _notificationService.GetMultiPaging(s => s.Receiver.Id == userId && s.IsDeleted != true, index, 5, new string[] { "Sender" });
            var listNotifications = new List<NotificationViewModel>();
            if (notifications.Count() != 0)
            {
                foreach (Notification i in notifications)
                {
                    var notificationViewModel = new NotificationViewModel()
                    {
                        Id = i.Id,
                        Type = Enum.GetName(typeof(NotificationType),i.Type),
                        SenderId = i.Sender.Id,
                        SenderAvatar = i.Sender.AvatarLocation,
                        SenderName = i.Sender.FullName
                    };
                    listNotifications.Add(notificationViewModel);
                }
                return Ok(listNotifications);
            }
            else
            {
                return Ok(listNotifications);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
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
            var notification = _notificationService.GetSingleByCondition(s => s.Id == id && s.Receiver.Id == userId, null);
            if(notification == null)
            {
                return Unauthorized();
            }
            notification.IsDeleted = true;
            _notificationService.Update(notification);
            _notificationService.SaveChanges();
            return NoContent();
        }
    }
}
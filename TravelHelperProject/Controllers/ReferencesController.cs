using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Services;
using TravelHelperProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReferencesController : ControllerBase
    {
        private IReferenceService _referenceService;
        private IUserService _userService;
        private INotificationService _notificationService;
        public ReferencesController(IReferenceService referenceService, IUserService userService, INotificationService notificationService)
        {
            _referenceService = referenceService;
            _userService = userService;
            _notificationService = notificationService;
        }
        [HttpPost]
        [Route("{id}")]
        public IActionResult PostReference(Reference reference, string id)
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
            reference.Sender = _userService.GetSingleByCondition(s => s.Id == userId, null);
            reference.Receiver = _userService.GetSingleByCondition(s => s.Id == id, null);
            if (reference.Receiver == null)
            {
                return NotFound();
            }
            reference.CreateDate = DateTime.Now;
            _referenceService.Add(reference);
            var notification = new Notification()
            {
                Type = NotificationType.Reference,
                Sender = reference.Sender,
                Receiver = reference.Receiver,
            };
            _notificationService.Add(notification);
            _referenceService.SaveChanges();
            return Ok(reference);
        }
    }
}
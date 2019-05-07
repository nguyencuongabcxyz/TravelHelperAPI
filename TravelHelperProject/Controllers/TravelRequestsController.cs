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
    public class TravelRequestsController : ControllerBase
    {
        private ITravelRequestService _travelRequestService;
        private IUserService _userService;
        private INotificationService _notificationService;
        public TravelRequestsController(ITravelRequestService travelRequestService, IUserService userService, INotificationService notificationService)
        {
            _travelRequestService = travelRequestService;
            _userService = userService;
            _notificationService = notificationService;
        }

        //Untested
        [HttpPost]
        [Route("{id}")]
        public IActionResult PostTravelRequest(TravelRequest travelRequest, string id)
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
            travelRequest.CreateDate = DateTime.Now;
            var traveler = _userService.GetSingleByCondition(s => s.Id == userId, null);
            var host = _userService.GetSingleByCondition(s => s.Id == id, null);
            if (host == null || traveler == null)
            {
                return NotFound();
            }
            var oldTravelRequests = _travelRequestService.GetMultiByCondition(s => s.Sender.Id == traveler.Id && s.Receiver.Id == host.Id, null);
            foreach (TravelRequest i in oldTravelRequests)
            {
                if (i.IsAccepted != true && i.IsCanceled != true)
                {
                    return BadRequest(new { message = "You already have unaccepted travelrequest with this user!" });
                }
            }
            travelRequest.Sender = traveler;
            travelRequest.Receiver = host;
            _travelRequestService.Add(travelRequest);
            _travelRequestService.SaveChanges();
            return Ok();
        }

        //Untested
        [HttpPut]
        [Route("{id}")]
        public IActionResult AcceptTravelRequest(int id)
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
            var travelRequest = _travelRequestService.GetSingleByCondition(s => s.TravelRequestId == id, new string[] {"Sender"} );
            if (travelRequest == null)
            {
                return NotFound();
            }
            if (receiver.Id != userId)
            {
                return Unauthorized();
            }
            travelRequest.IsAccepted = true;
            var notification = new Notification()
            {
                Type = NotificationType.TravelRequest,
                Sender = receiver,
                Receiver = travelRequest.Sender,
                CreateDate = DateTime.Now
            };
            _notificationService.Add(notification);
            _travelRequestService.SaveChanges();
            return Ok(travelRequest);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult IgnoreTravelRequest(int id)
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
            var travelRequest = _travelRequestService.GetSingleByCondition(s => s.TravelRequestId == id, new string[] { "Receiver" });
            if (travelRequest == null)
            {
                return NotFound();
            }
            if (travelRequest.Receiver.Id != userId)
            {
                return Unauthorized();
            }
            travelRequest.IsDeleted = true;
            _travelRequestService.SaveChanges();
            return NoContent();
        }
        [HttpPut("CancelRequest/{id}")]
        public IActionResult CancelTravelRequest(int id)
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
            var travelRequest = _travelRequestService.GetSingleByCondition(s => s.TravelRequestId == id, new string[] { "Sender" });
            if (travelRequest == null)
            {
                return NotFound();
            }
            if (travelRequest.Sender.Id != userId)
            {
                return Unauthorized();
            }
            travelRequest.IsDeleted = true;
            travelRequest.IsCanceled = true;
            _travelRequestService.SaveChanges();
            return NoContent();
        }
    }
}
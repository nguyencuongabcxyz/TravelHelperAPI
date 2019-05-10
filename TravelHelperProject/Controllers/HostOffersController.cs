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
    public class HostOffersController : ControllerBase
    {
        private IHostOfferService _hostOfferService;
        private IUserService _userService;
        private INotificationService _notificationService;
        public HostOffersController(IHostOfferService hostOfferService, IUserService userService, INotificationService notificationService)
        {
            _hostOfferService = hostOfferService;
            _userService = userService;
            _notificationService = notificationService;
        }
        //Untested
        [HttpPost]
        [Route("{id}")]
        public IActionResult PostHostOffer(HostOffer hostOffer, string id)
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
            hostOffer.CreateDate = DateTime.Now;
            var traveler = _userService.GetSingleByCondition(s => s.Id == id, null);
            var host = _userService.GetSingleByCondition(s => s.Id == userId, null);
            if (host == null || traveler == null)
            {
                return NotFound();
            }
            var oldHostOffers = _hostOfferService.GetMultiByCondition(s => s.Sender.Id == host.Id && s.Receiver.Id == traveler.Id, null);
            foreach(HostOffer i in oldHostOffers)
            {
                if(i.IsAccepted != true && i.IsCanceled!=true)
                {
                    return BadRequest(new { message = "You already have unaccepted hostoffer with this user!" });
                }
            }
            hostOffer.Receiver = traveler;
            hostOffer.Sender = host;
            _hostOfferService.Add(hostOffer);
            _hostOfferService.SaveChanges();
            return Ok();
        }

        //Untested
        [HttpPut]
        [Route("{id}")]
        public IActionResult AcceptHostOffer(int id)
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
            var hostOffer = _hostOfferService.GetSingleByCondition(s => s.HostOfferId == id, new string[] {"Sender"});
            if (hostOffer == null)
            {
                return NotFound();
            }
            if(receiver.Id != userId)
            {
                return NotFound();
            }
            var notification = new Notification()
            {
                Type = NotificationType.HostOffer,
                Sender = receiver,
                Receiver = hostOffer.Sender,
                CreateDate = DateTime.Now,
            };
            _notificationService.Add(notification);
            hostOffer.IsAccepted = true;
            _hostOfferService.SaveChanges();
            return Ok(hostOffer);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult IgnoreHostOffer(int id)
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
            var hostOffer = _hostOfferService.GetSingleByCondition(s => s.HostOfferId == id, new string[] { "Receiver" });
            if (hostOffer == null)
            {
                return NotFound();
            }
            if (hostOffer.Receiver.Id != userId)
            {
                return NotFound();
            }
            hostOffer.IsDeleted = true;
            _hostOfferService.SaveChanges();
            return NoContent();
        }
        [HttpPut("CancelOffer/{id}")]
        public IActionResult CancelHostOffer(int id)
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
            var hostOffer = _hostOfferService.GetSingleByCondition(s => s.HostOfferId == id, new string[] { "Sender" });
            if (hostOffer == null)
            {
                return NotFound();
            }
            if (hostOffer.Sender.Id != userId)
            {
                return NotFound();
            }
            hostOffer.IsDeleted = true;
            hostOffer.IsCanceled = true;
            _hostOfferService.SaveChanges();
            return NoContent();
        }
    }
}
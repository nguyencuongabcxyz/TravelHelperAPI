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
    public class HostOffersController : ControllerBase
    {
        private IHostOfferService _hostOfferService;
        private IUserService _userService;
        public HostOffersController(IHostOfferService hostOfferService, IUserService userService)
        {
            _hostOfferService = hostOfferService;
            _userService = userService;
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
            if (host == null)
            {
                return NotFound();
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
            var hostOffer = _hostOfferService.GetSingleByCondition(s => s.HostOfferId == id, new string[] {"Receiver"});
            if (hostOffer == null)
            {
                return NotFound();
            }
            if(hostOffer.Receiver.Id != userId)
            {
                return NotFound();
            }
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
    }
}
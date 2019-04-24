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
    public class TravelRequestsController : ControllerBase
    {
        private ITravelRequestService _travelRequestService;
        private IUserService _userService;
        public TravelRequestsController(ITravelRequestService travelRequestService, IUserService userService)
        {
            _travelRequestService = travelRequestService;
            _userService = userService;
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
            if (host == null)
            {
                return NotFound();
            }
            travelRequest.Traveler = traveler;
            travelRequest.Host = host;
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
            var travelRequest = _travelRequestService.GetSingleById(id);
            if (travelRequest == null)
            {
                return NotFound();
            }
            if (travelRequest.Host.Id != userId)
            {
                return Unauthorized();
            }
            travelRequest.IsAccepted = true;
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
            var travelRequest = _travelRequestService.GetSingleById(id);
            if (travelRequest == null)
            {
                return NotFound();
            }
            if (travelRequest.Host.Id != userId)
            {
                return Unauthorized();
            }
            travelRequest.IsDeleted = true;
            _travelRequestService.SaveChanges();
            return NoContent();
        }
    }
}
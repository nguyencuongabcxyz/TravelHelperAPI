using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelHelperProject.Models;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicTripsController : ControllerBase
    {
        private TravelHelperContext _travelHelperContext;
        public PublicTripsController(TravelHelperContext travelHelperContext)
        {
            _travelHelperContext = travelHelperContext;
        }
        //TESTED
        //GET api/Publictrips
        [HttpGet]
        public IActionResult GetPublicTrips()
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
            var publicTrips = _travelHelperContext.PublicTrips.Where(s => s.ApplicationUserId != userId && s.IsDeleted != true)
                .Include(s => s.User).ToList();
            if (publicTrips.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(publicTrips);
            }
        }
        //TESTED
        //GET api/Publictrips/Search?destination=destination
        [HttpGet]
        [Route("Search")]
        public IActionResult GetPublicTripsByDestination(string destination)
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
            var publicTrips = _travelHelperContext.PublicTrips.Where(s => s.ApplicationUserId != userId && s.Destination == destination && s.IsDeleted != true)
                .Include(s => s.User).ToList();
            if (publicTrips.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(publicTrips);
            }
        }
        //Untested on server
        //TESTED
        //POST api/Publictrips
        [HttpPost]
        public IActionResult PostPublicTrips(PublicTrip publicTrip)
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
            publicTrip.ApplicationUserId = userId;
            publicTrip.CreateDate = DateTime.Now;    
            try
            {
                _travelHelperContext.PublicTrips.Add(publicTrip);
                _travelHelperContext.SaveChanges();
                return Ok(publicTrip);
            }
            catch
            {
                return BadRequest();
            }
        }
        //TESTED
        //GET: api/PublicTrips/id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPublicTrip(int id)
        {
            var publicTrip = _travelHelperContext.PublicTrips.Find(id);
            if (publicTrip == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(publicTrip);
            }
        }
        //TESTED
        //PUT: api/PublicTrips/id
        [HttpPut]
        [Route("{id}")]
        public IActionResult PutPublicTrip(int id, PublicTrip publicTrip)
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
            var publicTripById = _travelHelperContext.PublicTrips.Where(s => s.PublicTripId == id).FirstOrDefault();
            if (publicTripById.ApplicationUserId != userId)
            {
                return Unauthorized(new { message = "Not allow to update other user's public trip!" });
            }
            if(publicTripById == null)
            {
                return NotFound();
            }
            publicTripById.ArrivalDate = publicTrip.ArrivalDate;
            publicTripById.DepartureDate = publicTrip.DepartureDate;
            publicTripById.Description = publicTrip.Description;
            publicTripById.TravelerNumber = publicTrip.TravelerNumber;
            publicTripById.Destination = publicTrip.Destination;
            _travelHelperContext.SaveChanges();
            return Ok(publicTripById);
        }

    }
}
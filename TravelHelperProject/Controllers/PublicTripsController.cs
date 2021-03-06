﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelHelperProject.Models;
using TravelHelperProject.Services;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PublicTripsController : ControllerBase
    {
        private IPublicTripService _publicTripService;
        private IUserService _userService;
        public PublicTripsController(IPublicTripService publicTripService, IUserService userService)
        {
            _publicTripService = publicTripService;
            _userService = userService;
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
            var user = _userService.GetSingleByCondition(s => s.Id == userId,null);
            string[] includes = { "User" };
            if(user.Address == null)
            {
                return Ok(new List<PublicTrip>());
            }
            var publicTrips = _publicTripService.GetMultiDescByDate(s => s.ApplicationUserId != userId && s.IsDeleted != true && DateTime.Compare((DateTime)s.ArrivalDate,DateTime.Now)>=0 && s.Destination.Equals(user.Address),s =>s.ArrivalDate, includes).Take(5).ToList();
            return Ok(publicTrips);
        }
        //TESTED
        //GET api/Publictrips/Search?destination=destination
        [HttpGet]
        [Route("Search")]
        public IActionResult GetPublicTripsByDestination(string destination, int index, int size = 14)
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
            string[] includes = { "User" };
            var publicTrips = _publicTripService.GetMultiPagingDescByDate(s => s.ApplicationUserId != userId && s.Destination.Contains(destination) && s.IsDeleted != true && DateTime.Compare((DateTime)s.ArrivalDate, DateTime.Now) >= 0, s => s.ArrivalDate, index, size, includes);
            return Ok(publicTrips);
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
                _publicTripService.Add(publicTrip);
                _publicTripService.SaveChanges();
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
            var publicTrip = _publicTripService.GetSingleByCondition(s => s.PublicTripId == id && s.IsDeleted != true, null);
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
            var publicTripById = _publicTripService.GetSingleByCondition(s => s.PublicTripId == id && s.IsDeleted!=true, null);
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
            _publicTripService.Update(publicTripById);
            _publicTripService.SaveChanges();
            return Ok(publicTripById);
        }
        //tested 
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePublicTrip(int id)
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
            var publicTripById = _publicTripService.GetSingleByCondition(s => s.PublicTripId == id, null);
            if(publicTripById == null)
            {
                return NotFound();
            }
            if (publicTripById.ApplicationUserId != userId)
            {
                return Unauthorized(new { message = "Not allow to delete other user's public trip!" });
            }
            publicTripById.IsDeleted = true;
            _publicTripService.Update(publicTripById);
            _publicTripService.SaveChanges();
            return NoContent();
        }
    }
}
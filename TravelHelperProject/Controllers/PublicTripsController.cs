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
        [HttpGet]
        public IActionResult GetPublicTrips()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var publicTrips = _travelHelperContext.PublicTrips.Where(s => s.ApplicationUserId != userId).ToList();
            return Ok(publicTrips);
        }
    }
}
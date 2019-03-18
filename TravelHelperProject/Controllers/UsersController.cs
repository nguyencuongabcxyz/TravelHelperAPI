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
    public class UsersController : ControllerBase
    {
        private TravelHelperContext _travelHelperContext;
        public UsersController(TravelHelperContext travelHelperContext)
        {
            _travelHelperContext = travelHelperContext;
        }
        //GET api/Users/id/publictrips
        [HttpGet]
        [Route("{id}/PublicTrips")]
        public IActionResult GetUserPublicTrip(string id)
        {
            var user = _travelHelperContext.ApplicationUsers.Where(s => s.Id == id)
                .Include(s => s.PublicTrips)
                .FirstOrDefault();
            if(user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
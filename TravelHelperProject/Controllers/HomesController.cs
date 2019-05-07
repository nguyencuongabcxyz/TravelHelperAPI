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
    public class HomesController : ControllerBase
    {
        private IHomeService _homeService;
        public HomesController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        //Untested
        // api/Home
        [HttpPost]
        public IActionResult PostHome(Home home)
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
            home.ApplicationUserId = userId;
            _homeService.Add(home);
            _homeService.SaveChanges();
            return Ok(home);
        }
        //Untested
        [HttpPut]
        [Route("{id}")]
        public IActionResult PutHome(int id, Home home)
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
            var homeById = _homeService.GetSingleById(id);
            if (homeById == null)
            {
                return NotFound();
            }
            if(homeById.ApplicationUserId != userId)
            {
                return Unauthorized(new { message = "Not allow to update other user's home!" });
            }
            homeById.MaxGuest = home.MaxGuest;
            homeById.PreferedGender = home.PreferedGender;
            homeById.SleepingArrangement = home.SleepingArrangement;
            homeById.SleepingDescription = home.SleepingDescription;
            homeById.Stuff = home.Stuff;
            homeById.TransportationAccess = home.TransportationAccess;
            homeById.AllowedThing = home.AllowedThing;
            homeById.AdditionInfo = home.AdditionInfo;
            _homeService.Update(homeById);
            _homeService.SaveChanges();
            return Ok(homeById);
        }
    }
}
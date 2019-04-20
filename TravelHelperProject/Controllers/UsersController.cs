using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TravelHelperProject.Commons;
using TravelHelperProject.Models;
using TravelHelperProject.Services;
using TravelHelperProject.ViewModels;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IImageFileService _imageFileService;
        private IBaseUrlHelper _baseUrlHelper;
        private IImageService _imageService;
        private IPublicTripService _publicTripService;
        private IHomeService _homeService;
        private IReferenceService _referenceService;

        public UsersController(IUserService userService, IImageFileService imageFileService, IBaseUrlHelper baseUrlHelper, IImageService imageService, IPublicTripService publicTripService, IHomeService homeService, IReferenceService referenceService)
        {
            this._userService = userService;
            this._imageFileService = imageFileService;
            this._baseUrlHelper = baseUrlHelper;
            this._imageService = imageService;
            this._publicTripService = publicTripService;
            this._homeService = homeService;
            this._referenceService = referenceService;
        }
        //Untested 
        //GET api/Users
        [HttpGet]
        public IActionResult GetUserProfile()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var user = _userService.GetSingleByCondition(s => s.Id == userId, null);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
        //Untested
        //GET api/User/id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserProfile(string id)
        {
            var user = _userService.GetSingleByCondition(s => s.Id == id, null);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //Tested
        //PUT api/Users
        [HttpPut]
        public IActionResult PutUserProfile(ProfileViewModel profile)
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var user = _userService.GetSingleByCondition(s => s.Id == userId, null);

            user.FullName = profile.FullName;
            user.Address = profile.Address;
            user.Gender = profile.Gender;
            user.Birthday = profile.Birthday;
            user.Occupation = profile.Occupation;
            user.FluentLanguage = profile.FluentLanguage;
            user.LearningLanguage = profile.LearningLanguage;
            user.About = profile.About;
            user.Interest = profile.Interest;
            user.Status = profile.Status;
            _userService.Update(user);
            _userService.SaveChanges();
            return Ok(user);

        }
        //Tested
        //GET: api/Users/Search?address=address
        [HttpGet]
        [Route("Search")]
        public IActionResult GetUserByAddress(string address)
        {
            var users = _userService.GetMultiByCondition(s => s.Address.Contains(address), null);
            return Ok(users);
        }

        //Untested
        //PUT: api/Users/Avatar
        [HttpPut]
        [Route("Avatar")]
        public async Task<IActionResult> PutUserAvatar([FromForm] IFormFile file)
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var imageName = await _imageFileService.UploadImage(file);
            if (!"failed".Equals(imageName))
            {
                var user = _userService.GetSingleByCondition(s => s.Id == userId, null);
                user.AvatarLocation = _baseUrlHelper.GetBaseUrl() + "/Images/" + imageName;
                _userService.Update(user);
                _userService.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest(new { message = "Invalid image type!" });
            }
        }
        [HttpGet]
        [Route("Images")]
        //GET api/Users/Images
        public IActionResult GetUserImages()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var images = _imageService.GetMultiByCondition(s => s.ApplicationUserId == userId && s.IsDeleted != true, null);
            return Ok(images);

        }
        [HttpGet]
        [Route("{id}/Images")]
        //GET api/Users/Images
        public IActionResult GetUserImages(string id)
        {
            var images = _imageService.GetMultiByCondition(s => s.ApplicationUserId == id && s.IsDeleted != true, null);
            return Ok(images);

        }
        [HttpGet]
        [Route("PublicTrips")]
        public IActionResult GetUserPublicTrips()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var publicTrips = _publicTripService.GetMultiByCondition(s => s.ApplicationUserId == userId && s.IsDeleted != true, null);
            return Ok(publicTrips);

        }
        [HttpGet]
        [Route("{id}/PublicTrips")]
        public IActionResult GetUserPublicTrips(string id)
        {
            var publicTrips = _publicTripService.GetMultiByCondition(s => s.ApplicationUserId == id && s.IsDeleted != true, null);
            return Ok(publicTrips);
        }
        [HttpGet]
        [Route("Homes")]
        public IActionResult GetUserHome()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var home = _homeService.GetMultiByCondition(s => s.ApplicationUserId == userId, null);
            return Ok(home);
        }
        [HttpGet]
        [Route("{id}/Homes")]
        public IActionResult GetUserHome(string id)
        {
            var home = _homeService.GetMultiByCondition(s => s.ApplicationUserId == id, null);
            return Ok(home);
        }
        [HttpGet]
        [Route("References")]
        public IActionResult GetUserReferences()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            string[] includes = { "Sender" };
            var references = _referenceService.GetMultiByCondition(s => s.Receiver.Id == userId && s.IsDeleted != true, includes);
            return Ok(references);
        }
        [HttpGet]
        [Route("{id}/References")]
        public IActionResult GetUserReferences(string id)
        {
            string[] includes = { "Sender" };
            var references = _referenceService.GetMultiByCondition(s => s.Receiver.Id == id && s.IsDeleted != true, includes);
            return Ok(references);
        }
        [NonAction]
        public string GetUserId()
        {
            string userId;
            try
            {
                userId = User.Claims.First(c => c.Type == "UserID").Value;
            }
            catch
            {
                return "error";
            }
            return userId;
        }
    }
}
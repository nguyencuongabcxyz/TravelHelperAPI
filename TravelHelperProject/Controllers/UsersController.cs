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
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IImageFileService _imageFileService;
        private IBaseUrlHelper _baseUrlHelper;
        private IImageService _imageService;
        private IPublicTripService _publicTripService;
        private IHomeService _homeService;
        private IReferenceService _referenceService;
        private ITravelRequestService _travelRequestService;
        private IHostOfferService _hostOfferService;
        private IFriendRequestService _friendRequestService;
        private IFriendService _friendService;
        private IMessageService _messageService;
        private IMessageSenderService _messageSenderService;

        public UsersController(IUserService userService, IImageFileService imageFileService, IBaseUrlHelper baseUrlHelper,
            IImageService imageService, IPublicTripService publicTripService,
            IHomeService homeService, IReferenceService referenceService,
            ITravelRequestService travelRequestService, IHostOfferService hostOfferService,
            IFriendRequestService friendRequestService, IFriendService friendService,
            IMessageService messageService, IMessageSenderService messageSenderService)
        {
            _userService = userService;
            _imageFileService = imageFileService;
            _baseUrlHelper = baseUrlHelper;
            _imageService = imageService;
            _publicTripService = publicTripService;
            _homeService = homeService;
            _referenceService = referenceService;
            _travelRequestService = travelRequestService;
            _hostOfferService = hostOfferService;
            _friendRequestService = friendRequestService;
            _friendService = friendService;
            _messageService = messageService;
            _messageSenderService = messageSenderService;
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

        [HttpGet]
        [Route("SearchByName")]
        public IActionResult GetUserByName(string name)
        {
            var users = _userService.GetMultiByCondition(s => s.FullName.Contains(name), null);
            return Ok(users);
        }
        //Untested
        //POST: api/Users/Avatar
        [HttpPost]
        [Route("Avatar")]
        public async Task<IActionResult> PostUserAvatar([FromForm] IFormFile file)
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
            var publicTrips = _publicTripService.GetMultiDescByDate(s => s.ApplicationUserId == userId && s.IsDeleted != true, s => s.ArrivalDate, null).ToList();
            return Ok(publicTrips);

        }
        [HttpGet]
        [Route("{id}/PublicTrips")]
        public IActionResult GetUserPublicTrips(string id)
        {
            var publicTrips = _publicTripService.GetMultiDescByDate(s => s.ApplicationUserId ==id && s.IsDeleted != true && DateTime.Compare((DateTime)s.ArrivalDate, DateTime.Now) >= 0 , s => s.ArrivalDate, null).ToList();
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

        //TravelRequest section 
        [HttpGet]
        [Route("TravelRequests")]
        public IActionResult GetUserTravelRequests()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var travelRequests = _travelRequestService.GetMultiByCondition(s => s.Receiver.Id == userId && s.IsDeleted != true && s.IsCanceled !=true,new string[] {"Sender"});
            return Ok(travelRequests);
        }

        [HttpGet]
        [Route("SentTravelRequests")]
        public IActionResult GetUserSentTravelRequests()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var sentTravelRequests = _travelRequestService.GetMultiByCondition(s => s.Sender.Id == userId && s.IsAccepted != true && s.IsDeleted != true, new string[] { "Receiver" });
            return Ok(sentTravelRequests);
        }
        //HostOffer Section 
        [HttpGet]
        [Route("HostOffers")]
        public IActionResult GetUserHostOffers()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var hostOffers = _hostOfferService.GetMultiByCondition(s => s.Receiver.Id == userId && s.IsDeleted != true && s.IsCanceled != true, new string[] { "Sender" });
            return Ok(hostOffers);
        }

        [HttpGet]
        [Route("SentHostOffers")]
        public IActionResult GetUserSentHostOffers()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var sentHostOffers = _hostOfferService.GetMultiByCondition(s => s.Sender.Id == userId && s.IsDeleted != true && s.IsAccepted!=true, new string[] { "Receiver" });
            return Ok(sentHostOffers);
        }
        //Friend request Section
        [HttpGet]
        [Route("FriendRequests")]
        public IActionResult GetFriendRequests()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var friendRequests = _friendRequestService.GetMultiByCondition(s => s.Receiver.Id == userId && s.IsDeleted != true && s.IsAccepted!=true && s.IsCanceled != true, new string[] { "Sender" });
            return Ok(friendRequests);
        }

        [HttpGet]
        [Route("SentFriendRequests")]
        public IActionResult GetSentFriendRequests()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var sentFriendRequests = _friendRequestService.GetMultiByCondition(s => s.Sender.Id == userId && s.IsDeleted != true && s.IsAccepted !=true, new string[] { "Receiver" });
            return Ok(sentFriendRequests);
        }
        //Friend Section
        [HttpGet("Friends")]
        public IActionResult GetFriends()
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var friendList = new List<ApplicationUser>();
            var friends = _friendService.GetMultiByCondition(s => s.ApplicationUser1.Id == userId || s.ApplicationUser2.Id == userId && s.IsDeleted != true, new string[] {"ApplicationUser1","ApplicationUser2"});
            foreach(Friend i in friends)
            {
                if(i.ApplicationUser1.Id == userId)
                {
                    i.ApplicationUser2.FriendsUser2 = null;
                    friendList.Add(i.ApplicationUser2);
                }
                else
                {
                    i.ApplicationUser1.FriendsUser1= null;
                    friendList.Add(i.ApplicationUser1);
                }
            }
            return Ok(friendList);
        }

        [HttpGet("MessageSenders")]
        public IActionResult GetMessageSenders(int index)
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var senders = _messageSenderService.GetMessageSenders(userId,index);
            return Ok(senders);
        }
        [HttpGet("Messages/{id}")]
        public IActionResult GetMessages(string id,int index)
        {
            string userId = GetUserId();
            if (userId == "error")
            {
                return Unauthorized();
            }
            var messages = _messageService.GetMessagesPaging(s => (s.Sender.Id == userId && s.Receiver.Id == id) || (s.Receiver.Id == userId && s.Sender.Id == id), index,10,new string[] {"Sender","Receiver"});
            var result = new List<MessageViewModel>();
            foreach(Message i in messages)
            {
                var check = true;
                if(i.Sender.Id == id)
                {
                    check = false;
                }
                var message = new MessageViewModel()
                {
                    Id = i.MessageId,
                    Content = i.Content,
                    CreateDate = i.CreateDate,
                    IsYou = check,
                    Avatar = i.Sender.AvatarLocation,
                };
                result.Add(message);
            }
            result.Reverse();
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Lock/{id}")]
        public IActionResult LockUser(string id)
        {
            var user = _userService.GetSingleByCondition(s => s.Id == id, null);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = false;
            _userService.Update(user);
            _userService.SaveChanges();
            return Ok(user);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Unlock/{id}")]
        public IActionResult UnlockUser(string id)
        {
            var user = _userService.GetSingleByCondition(s => s.Id == id, null);
            if (user == null)
            {
                return NotFound();
            }
            user.IsActive = true;
            _userService.Update(user);
            _userService.SaveChanges();
            return Ok(user);
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
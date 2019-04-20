using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Services;
using TravelHelperProject.Models;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private IReferenceService _referenceService;
        private IUserService _userService;
        public ReferencesController(IReferenceService referenceService, IUserService userService)
        {
            _referenceService = referenceService;
            _userService = userService;
        }
        [HttpPost]
        [Route("{id}")]
        public IActionResult PostReference(Reference reference, string id)
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
            reference.Sender = _userService.GetSingleByCondition(s => s.Id == userId, null);
            reference.Receiver = _userService.GetSingleByCondition(s => s.Id == id, null);
            if (reference.Receiver == null)
            {
                return NotFound();
            }
            reference.CreateDate = DateTime.Now;
            _referenceService.Add(reference);
            _referenceService.SaveChanges();
            return Ok(reference);
        }
    }
}
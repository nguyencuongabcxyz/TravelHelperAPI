using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelHelperProject.Commons;
using TravelHelperProject.Models;
using TravelHelperProject.Services;

namespace TravelHelperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImagesController : ControllerBase
    {
        private IImageFileService _imageFileService;
        private IImageService _imageService;
        private IBaseUrlHelper _baseUrlHelper;
        public ImagesController(IImageFileService imageFileService, IImageService imageService,IBaseUrlHelper baseUrlHelper)
        {
            _imageFileService = imageFileService;
            _imageService = imageService;
            _baseUrlHelper = baseUrlHelper;
        }
        [HttpPost]
        //[Route("Upload")]
        public async Task<IActionResult> PostImage([FromForm] IFormFile file)
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
            var imageName = await _imageFileService.UploadImage(file);
            if (!"failed".Equals(imageName))
            {
                Photo photo = new Photo()
                {
                    Name = imageName,
                    Location = _baseUrlHelper.GetBaseUrl() + "/Images/" + imageName,
                    CreateDate = DateTime.Now,
                    ApplicationUserId = userId
                };
                _imageService.Add(photo);
                _imageService.SaveChanges();
                return Ok(photo);
            }
            else
            {
                return BadRequest(new { message = "Invalid image type!"});
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteImage(int id)
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
            var photo = _imageService.GetSingleByCondition(s => s.PhotoId == id && s.IsDeleted != true,null);
            if (photo == null)
            {
                return NotFound();
            }
            if(photo.ApplicationUserId != userId)
            {
                return Unauthorized(new { message = "Not allowed to modify other user's images!!" });
            }
            var result = _imageFileService.DeleteImage(photo.Name);
            if (result != true)
            {
                return NotFound();
            }
            else
            {
                photo.IsDeleted = true;
                _imageService.Update(photo);
                _imageService.SaveChanges();
                return NoContent();
            }
        }

    }
}
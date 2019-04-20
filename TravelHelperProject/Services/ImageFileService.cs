using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Commons;
using TravelHelperProject.Models;

namespace TravelHelperProject.Services
{
    public interface IImageFileService
    {
        Task<string> UploadImage(IFormFile file);
        bool DeleteImage(string fileName);
        //Task<IActionResult> UploadAvatar(IFormFile file);

    }
    public class ImageFileService: IImageFileService
    {
        private IImageWriter _imageWriter;
        public ImageFileService(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return result;
        }
        public bool DeleteImage(string fileName)
        {
            return _imageWriter.DeleteImage(fileName);
        }
    }
}

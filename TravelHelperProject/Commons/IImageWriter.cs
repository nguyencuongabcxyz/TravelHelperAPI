using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.Commons
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
        bool DeleteImage(string fileName);
    }
}

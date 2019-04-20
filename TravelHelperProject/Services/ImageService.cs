using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IImageService: ICommonService<Photo>
    {

    }
    public class ImageService: CommonService<Photo, IImageRepository>, IImageService
    {
        private IImageRepository _imageRepository;
        private IUnitOfWork _unitOfWork;
        public ImageService( IImageRepository imageRepository, IUnitOfWork unitOfWork):base(unitOfWork,imageRepository)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IImageRepository: IBaseRepository<Photo>
    {
    }
    public class ImageRepository: BaseRepository<Photo>, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

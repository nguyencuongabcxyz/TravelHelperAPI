using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IHomeRepository: IBaseRepository<Home>
    {

    }
    public class HomeRepository: BaseRepository<Home>, IHomeRepository
    {
        public HomeRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface ITravelRequestRepository: IBaseRepository<TravelRequest>
    {

    }

    public class TravelRequestRepository: BaseRepository<TravelRequest>, ITravelRequestRepository
    {
        public TravelRequestRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}

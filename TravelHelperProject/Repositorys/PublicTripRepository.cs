using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IPublicTripRepository: IBaseRepository<PublicTrip>
    {

    }
    public class PublicTripRepository: BaseRepository<PublicTrip>, IPublicTripRepository
    {
        public PublicTripRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

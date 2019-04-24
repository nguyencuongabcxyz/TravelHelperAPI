using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IHostOfferRepository: IBaseRepository<HostOffer>
    {

    }
    public class HostOfferRepository: BaseRepository<HostOffer>, IHostOfferRepository
    {
        public HostOfferRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

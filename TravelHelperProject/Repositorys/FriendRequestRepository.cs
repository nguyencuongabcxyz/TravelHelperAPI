using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IFriendRequestRepository: IBaseRepository<FriendRequest>
    {

    }
    public class FriendRequestRepository: BaseRepository<FriendRequest>, IFriendRequestRepository
    {
        public FriendRequestRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

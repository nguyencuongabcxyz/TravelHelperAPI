using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IFriendRepository: IBaseRepository<Friend>
    {

    }
    public class FriendRepository: BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

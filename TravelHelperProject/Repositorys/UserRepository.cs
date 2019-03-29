using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IUserRepository: IBaseRepository<ApplicationUser>
    {

    }
    public class UserRepository: BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory):base(dbFactory)
        {
        }
    }
}

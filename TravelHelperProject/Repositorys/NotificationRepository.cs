using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface INotificationRepository: IBaseRepository<Notification>
    {

    }
    public class NotificationRepository: BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

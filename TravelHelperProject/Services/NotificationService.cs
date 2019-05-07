using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface INotificationService: ICommonService<Notification>
    {

    }
    public class NotificationService: CommonService<Notification,INotificationRepository>, INotificationService
    {
        private INotificationRepository _notificationRepository;
        private IUnitOfWork _unitOfWork;
        public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork):base(unitOfWork, notificationRepository)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

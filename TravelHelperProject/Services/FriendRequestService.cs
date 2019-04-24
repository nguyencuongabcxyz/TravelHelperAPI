using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IFriendRequestService: ICommonService<FriendRequest>
    {

    }
    public class FriendRequestService: CommonService<FriendRequest, IFriendRequestRepository>, IFriendRequestService
    {
        private IFriendRequestRepository _friendRequestRepository;
        private IUnitOfWork _unitOfWork;

        public FriendRequestService(IFriendRequestRepository friendRequestRepository, IUnitOfWork unitOfWork): base(unitOfWork, friendRequestRepository)
        {
            _friendRequestRepository = friendRequestRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

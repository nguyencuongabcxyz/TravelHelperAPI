using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IFriendService: ICommonService<Friend>
    {

    }
    public class FriendService: CommonService<Friend, IFriendRepository>, IFriendService
    {
        private IFriendRepository _friendRepository;
        private IUnitOfWork _unitOfWork;

        public FriendService(IFriendRepository friendRepository, IUnitOfWork unitOfWork):base(unitOfWork,friendRepository)
        {
            _friendRepository = friendRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

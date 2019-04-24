using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface ITravelRequestService: ICommonService<TravelRequest>
    {

    }
    public class TravelRequestService: CommonService<TravelRequest, ITravelRequestRepository>, ITravelRequestService
    {
        private ITravelRequestRepository _travelRequestRepository;
        private IUnitOfWork _unitOfWork;
        public TravelRequestService(ITravelRequestRepository travelRequestRepository, IUnitOfWork unitOfWork) : base(unitOfWork, travelRequestRepository)
        {
            _travelRequestRepository = travelRequestRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

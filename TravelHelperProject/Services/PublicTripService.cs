using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IPublicTripService: ICommonService<PublicTrip>
    {
    }
    public class PublicTripService: CommonService<PublicTrip, IPublicTripRepository>, IPublicTripService
    {
        private IPublicTripRepository _publicTripRepository;
        private IUnitOfWork _unitOfWork;

        public PublicTripService(IPublicTripRepository publicTripRepository, IUnitOfWork unitOfWork):base(unitOfWork, publicTripRepository)
        {
            _publicTripRepository = publicTripRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

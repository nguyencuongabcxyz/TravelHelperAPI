using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IHostOfferService: ICommonService<HostOffer>
    {

    }
    public class HostOfferService: CommonService<HostOffer, IHostOfferRepository>, IHostOfferService
    {
        private IHostOfferRepository _hostOfferRepository;
        private IUnitOfWork _unitOfWork;
        public HostOfferService(IHostOfferRepository hostOfferRepository, IUnitOfWork unitOfWork):base(unitOfWork, hostOfferRepository)
        {
            _hostOfferRepository = hostOfferRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

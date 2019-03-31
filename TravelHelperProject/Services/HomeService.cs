using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IHomeService: ICommonService<Home>
    {

    }
    public class HomeService: CommonService<Home, IHomeRepository>, IHomeService
    {
        private IHomeRepository _homeRepository;
        private IUnitOfWork _unitOfWork;
        public HomeService(IHomeRepository homeRepository, IUnitOfWork unitOfWork):base(unitOfWork, homeRepository)
        {
            _homeRepository = homeRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

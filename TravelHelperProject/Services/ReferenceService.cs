using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IReferenceService: ICommonService<Reference>
    {

    }
    public class ReferenceService: CommonService<Reference, IReferenceRepository>, IReferenceService
    {
        private IReferenceRepository _referenceRepository;
        private IUnitOfWork _unitOfWork;
        public ReferenceService(IReferenceRepository referenceRepository, IUnitOfWork unitOfWork):base(unitOfWork,referenceRepository)
        {
            _referenceRepository = referenceRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

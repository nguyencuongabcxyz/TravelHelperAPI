using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IReportService: ICommonService<Report>
    {

    }
    public class ReportService: CommonService<Report, IReportRepository>, IReportService
    {
        private IReportRepository _reportRepository;
        private IUnitOfWork _unitOfWork;
        public ReportService( IReportRepository reportRepository, IUnitOfWork unitOfWork):base(unitOfWork,reportRepository)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
        }
    }
}

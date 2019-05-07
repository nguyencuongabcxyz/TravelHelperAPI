using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IReportRepository: IBaseRepository<Report>
    {

    }
    public class ReportRepository: BaseRepository<Report> , IReportRepository
    {
        public ReportRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

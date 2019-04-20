using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IReferenceRepository: IBaseRepository<Reference>
    {

    }
    public class ReferenceRepository: BaseRepository<Reference>, IReferenceRepository
    {
        public ReferenceRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}

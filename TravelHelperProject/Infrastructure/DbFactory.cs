using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Models;

namespace TravelHelperProject.Infrastructure
{
    public class DBFactory: IDBFactory
    {
        private TravelHelperContext _travelHelperContext;
        public TravelHelperContext Init()
        {
            string _connectionString = "Server=tcp:nguyencuongoc.database.windows.net,1433;Initial Catalog=TravelHelperProject;Persist Security Info=False;User ID=nguyencuongoc;Password=Abcxyz123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var optionsBuilder = new DbContextOptionsBuilder<TravelHelperContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return _travelHelperContext ?? (_travelHelperContext = new TravelHelperContext(optionsBuilder.Options));
        }
    }
}

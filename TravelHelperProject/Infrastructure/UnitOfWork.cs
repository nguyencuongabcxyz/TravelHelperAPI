using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Models;

namespace TravelHelperProject.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TravelHelperContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public TravelHelperContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}

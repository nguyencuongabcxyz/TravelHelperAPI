using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Models;

namespace TravelHelperProject.DataAccess
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T:class
    {
        protected DbSet<T> _dbSet;
        private TravelHelperContext _travelHelperContext;
        public BaseRepository(TravelHelperContext travelHelperContext)
        {
            _travelHelperContext = travelHelperContext;
            _dbSet = _travelHelperContext.Set<T>();
        } 
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _travelHelperContext.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public abstract T GetRecordById(int id);
        public abstract T GetRecordById(string id);
        public abstract IEnumerable<T> GetAllRecords();
    }
}

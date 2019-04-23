using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.DataAccess
{
    public class BaseRepository<T>: IBaseRepository<T> where T:class
    {
        protected DbSet<T> _dbSet;
        private TravelHelperContext _travelHelperContext;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected TravelHelperContext TravelHelperContext
        {
            get { return _travelHelperContext ?? (_travelHelperContext = DbFactory.Init()); }
        }
        public BaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = TravelHelperContext.Set<T>();
        } 
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            TravelHelperContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Remove(T entity)
        {

        }
        public T GetSingleById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual T GetSingleByCondition(Expression<Func<T,bool>> expression,string[] includes)
        {
            if(includes!=null && includes.Count() > 0)
            {
                var query = TravelHelperContext.Set<T>().Include(includes.First());
                foreach(string i in includes.Skip(1))
                {
                    query = query.Include(i);
                }
                return query.FirstOrDefault(expression);
            }
            return TravelHelperContext.Set<T>().FirstOrDefault(expression);
        }
        public virtual IEnumerable<T> GetAll(string [] includes)
        {
            if(includes!=null && includes.Count() > 0)
            {
                var query = TravelHelperContext.Set<T>().Include(includes.First());
                foreach(string i in includes.Skip(1))
                {
                    query = query.Include(i);
                }
                return query.AsQueryable();
            }
            return TravelHelperContext.Set<T>().AsQueryable();
        }
        public virtual IEnumerable<T> GetMultiByCondition(Expression<Func<T,bool>> expression, string [] includes)
        {
            if(includes!=null && includes.Count() > 0)
            {
                var query = TravelHelperContext.Set<T>().Include(includes.First());
                foreach(string i in includes.Skip(1))
                {
                    query = query.Include(i);
                }
                return query.Where<T>(expression).AsQueryable();
            }
            return TravelHelperContext.Set<T>().Where<T>(expression).AsQueryable();
        }
        public virtual IEnumerable<T> GetMultiDescByDate(Expression<Func<T, bool>> expression, Expression<Func<T, DateTime?>> property, string[] includes)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = TravelHelperContext.Set<T>().Include(includes.First());
                foreach (string i in includes.Skip(1))
                {
                    query = query.Include(i);
                }
                return query.Where<T>(expression).OrderByDescending(property).AsQueryable();
            }
            return TravelHelperContext.Set<T>().OrderByDescending(property).Where<T>(expression).AsQueryable();
        }
    }
}

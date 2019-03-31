using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TravelHelperProject.DataAccess
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes);
        T GetSingleById(int id);
        IEnumerable<T> GetAll(string[] includes);
        IEnumerable<T> GetMultiByCondition(Expression<Func<T, bool>> expression, string[] includes);
    }
}

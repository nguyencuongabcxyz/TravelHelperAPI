using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperProject.DataAccess
{
    interface IBaseRepository<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetRecordById(int id);
        T GetRecordById(string id);
        IEnumerable<T> GetAllRecords();

    }
}

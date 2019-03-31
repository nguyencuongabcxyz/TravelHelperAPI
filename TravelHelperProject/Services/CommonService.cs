using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Services
{
    public interface ICommonService<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        //void DeleteSingle(T entity);
        void SaveChanges();
        T GetSingleById(int id);
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes);
        IEnumerable<T> GetAll(string[] includes);
        IEnumerable<T> GetMultiByCondition(Expression<Func<T, bool>> expression, string[] includes);
    }
    public class CommonService<T,R>: ICommonService<T> 
        where T: class 
        where R: IBaseRepository<T>
    {
        private R _repository;
        private IUnitOfWork _unitOfWork;
        public CommonService(IUnitOfWork unitOfWork, R repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _repository.Add(entity);
        }
        public void Update(T entity)
        {
            _repository.Update(entity);
        }
        //public void DeleteSingle(T entity)
        //{
        //    entity.IsDeleted = true;
        //    _repository.Update(entity);
        //}
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
        public T GetSingleById(int id)
        {
            return _repository.GetSingleById(id);
        }
        public T GetSingleByCondition(Expression<Func<T,bool>> expression,string [] includes)
        {
            return _repository.GetSingleByCondition(expression, includes);
        }
        public IEnumerable<T> GetAll(string [] includes)
        {
            return _repository.GetAll(includes);
        }
        public IEnumerable<T> GetMultiByCondition(Expression<Func<T,bool>> expression, string [] includes)
        {
            return _repository.GetMultiByCondition(expression, includes);
        }
        
    }
}

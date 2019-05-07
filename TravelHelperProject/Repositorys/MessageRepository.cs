using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelperProject.DataAccess;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;

namespace TravelHelperProject.Repositorys
{
    public interface IMessageRepository: IBaseRepository<Message>
    {
        IEnumerable<Message> GetMessagesPaging(Expression<Func<Message, bool>> expression, int index = 0, int size = 5, string[] includes = null);
    }
    public class MessageRepository: BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(IDbFactory dbFactory):base(dbFactory)
        {
        }
        public IEnumerable<Message> GetMessagesPaging(Expression<Func<Message, bool>> expression, int index = 0, int size = 5, string[] includes = null)
        {
            var skipCount = index * size;
            IQueryable<Message> _resetSet = null;
            if (includes != null && includes.Count() > 0)
            {
                var query = TravelHelperContext.Set<Message>().Include(includes.First());
                foreach (string i in includes.Skip(1))
                {
                    query = query.Include(i);
                }
                _resetSet = expression != null ? query.Where<Message>(expression).OrderByDescending(s => s.CreateDate).AsQueryable() : query.OrderByDescending(s => s.CreateDate).AsQueryable();
            }
            else
            {
                _resetSet = expression != null ? TravelHelperContext.Set<Message>().Where<Message>(expression).OrderByDescending(s => s.CreateDate).AsQueryable() : TravelHelperContext.Set<Message>().OrderByDescending(s => s.CreateDate).AsQueryable();
            }
            _resetSet = index == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            return _resetSet.AsQueryable();
        }
    }
}

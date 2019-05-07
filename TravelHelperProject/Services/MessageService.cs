using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelHelperProject.Infrastructure;
using TravelHelperProject.Models;
using TravelHelperProject.Repositorys;

namespace TravelHelperProject.Services
{
    public interface IMessageService : ICommonService<Message>
    {
        IEnumerable<Message> GetMessagesPaging(Expression<Func<Message, bool>> expression, int index = 0, int size = 5, string[] includes = null);
    }
    public class MessageService : CommonService<Message, IMessageRepository>, IMessageService
    {
        private IMessageRepository _messageRepository;
        private IUnitOfWork _unitOfWork;
        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork) : base(unitOfWork, messageRepository)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Message> GetMessagesPaging(Expression<Func<Message, bool>> expression, int index = 0, int size = 5, string[] includes = null)
        {
            return _messageRepository.GetMessagesPaging(expression, index, size, includes);
        }
    }
}

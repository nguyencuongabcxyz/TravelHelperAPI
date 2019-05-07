using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperProject.Models;
using TravelHelperProject.ViewModels;

namespace TravelHelperProject.Services
{
    public interface IMessageSenderService
    {
        IEnumerable<MessageSenderViewModel> GetMessageSenders(string id,int index =0, int size =5, string[] includes = null);
    }
    public class MessageSenderService: IMessageSenderService
    {
        private IMessageService _messageService;
        private IUserService _userService;
        public MessageSenderService(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }
        public IEnumerable<MessageSenderViewModel> GetMessageSenders(string id,int index =0, int size =5, string[] includes =null)
        {
            var skipCount = size * index;
            //var senders =index ==0 ? _messageService.GetMultiByCondition(s => s.Receiver.Id == id, new string[] { "Sender"}).OrderByDescending(s => s.CreateDate).Select(s => s.Sender.Id).Distinct().Take(size) : _messageService.GetMultiByCondition(s => s.Receiver.Id == id, new string[] { "Sender" }).OrderByDescending(s => s.CreateDate).Select(s => s.Sender.Id).Distinct().Skip(skipCount).Take(size);
            var sendersMessage = _messageService.GetMultiByCondition(s => s.Receiver.Id == id, new string[] { "Sender" }).ToList();
            var receiversMessage = _messageService.GetMultiByCondition(s => s.Sender.Id == id, new string[] { "Receiver" }).ToList();
            foreach (Message i in receiversMessage)
            {
                var message = new Message()
                {
                    MessageId = i.MessageId,
                    Content = i.Content,
                    CreateDate = i.CreateDate,
                    Sender = i.Receiver,
                    Receiver = i.Sender
                };
                sendersMessage.Add(message);
            }
            var senders = index == 0 ? sendersMessage.OrderByDescending(s => s.CreateDate).Select(s => s.Sender.Id).Distinct().Take(size) : sendersMessage.OrderByDescending(s => s.CreateDate).Select(s => s.Sender.Id).Distinct().Skip(skipCount).Take(size);


            var senderUsers = new List<ApplicationUser>();
            foreach(string i in senders)
            {
                var user = _userService.GetSingleByCondition(s => s.Id == i, null);
                senderUsers.Add(user);
            }
            var newestMessages = new List<string>();
            var createDates = new List<DateTime?>();
            foreach(ApplicationUser i in senderUsers)
            {
                var newestMessage = _messageService.GetMultiByCondition(s => (s.Sender.Id == i.Id && s.Receiver.Id == id) || (s.Sender.Id == id && s.Receiver.Id == i.Id), null).OrderByDescending(s => s.CreateDate).Take(1).ToList();
                newestMessages.Add(newestMessage[0].Content);
                createDates.Add(newestMessage[0].CreateDate);
            }
            var messageSenders = new List<MessageSenderViewModel>();
            for(int i =0;i < senderUsers.Count; i++)
            {
                var messageSender = new MessageSenderViewModel()
                {
                    Id = senderUsers[i].Id,
                    Avatar = senderUsers[i].AvatarLocation,
                    FullName = senderUsers[i].FullName,
                    LastedMessage = newestMessages[i],
                    CreateDate = createDates[i]
                };
                messageSenders.Add(messageSender);
            }
            return messageSenders;
        }
    }
}

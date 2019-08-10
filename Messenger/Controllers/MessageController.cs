using AutoMapper;
using MessangerBL.Interfaces;
using MessangerBL.Models;
using Messenger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    public class MessageController : Controller
    {
        private readonly IMessageService userService;
        private readonly INotificationService notificationService;

        public MessageController(IMessageService userService, INotificationService notificationService)
        {
            this.userService = userService;
            this.notificationService = notificationService;
        }

        [HttpPost]
        public async Task<string> SaveAsync([FromBody]CreateMessageViewModel message)
        {
            NotificationDTO notification = new NotificationDTO
            {
                Body = message.Body,
                Recipients = message.Recipients!= null ? string.Join(';', message.Recipients) : string.Empty
            };
            //var isSent = await notificationService.SendMessageToNotificationServiceAsync(notification);

            var mapperCreateMessageViewModelToMessageDTO = new MapperConfiguration(cfg => cfg.CreateMap<CreateMessageViewModel, MessageDTO>()).CreateMapper();
            var messageDTO = mapperCreateMessageViewModelToMessageDTO.Map<CreateMessageViewModel, MessageDTO>(message);

            messageDTO.IsSent = false;

            return await userService.SaveAsync(messageDTO);
        }

        [HttpGet]
        public async Task<IEnumerable<IndexMessageViewModel>> AllAsync()
        {
            var messagesDTO = await userService.AllAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, IndexMessageViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<MessageDTO>, IEnumerable<IndexMessageViewModel>>(messagesDTO);
        }
    }
}
using AutoMapper;
using Messenger.Models;
using MessengerBL.Interfaces;
using MessengerBL.Models;
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

        public MessageController(IMessageService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<string> SaveAsync([FromBody]CreateMessageViewModel message)
        {
            var mapperCreateMessageViewModelToMessageDTO = new MapperConfiguration(cfg => cfg.CreateMap<CreateMessageViewModel, MessageDTO>()).CreateMapper();
            var messageDTO = mapperCreateMessageViewModelToMessageDTO.Map<CreateMessageViewModel, MessageDTO>(message);
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
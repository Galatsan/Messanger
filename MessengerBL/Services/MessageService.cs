using AutoMapper;
using MessangerBL.Interfaces;
using MessangerBL.Models;
using MessangerData.Interfaces;
using MessangerData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessangerBL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository userRepository;

        public MessageService(IMessageRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<string> SaveAsync(MessageDTO entity)
        {
            return await Task.Run(() =>
            {
                var mapperMessageToDTOMessage = new MapperConfiguration(cfg => cfg.CreateMap<MessageDTO, Message>()).CreateMapper();
                var message = mapperMessageToDTOMessage.Map<MessageDTO, Message>(entity);
                return userRepository.Save(message);
            });
        }

        public async Task<IEnumerable<MessageDTO>> AllAsync()
        {
            return await Task.Run(() =>
            {
                IEnumerable<Message> messages = new List<Message>();
                messages = userRepository.All();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Message, MessageDTO>()).CreateMapper();

                var result = new List<MessageDTO>();
                foreach (var message in messages)
                {
                    result.Add(mapper.Map<Message, MessageDTO>(message));
                }
                return result;
            });
        }
    }
}

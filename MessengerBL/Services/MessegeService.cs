using AutoMapper;
using MessangerBL.Models;
using MessengerBL.Interfaces;
using MessengerBL.Models;
using MessengerData.Interfaces;
using MessengerData.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MessengerBL.Services
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
            entity.IsSent = await SendMessageToNotificationServiceAsync(new NotificationDTO
            {
                Body = entity.Body,
                Recipients = string.Join(';', entity.Recipients)
            });

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

        private async Task<bool> SendMessageToNotificationServiceAsync(NotificationDTO notification)
        {
            var result = false;
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(notification);
                    client.BaseAddress = new Uri("http://test:8080");
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("notification", json)
                    });
                    var httpResult = await client.PostAsync("/api/Notification", content);
                    var resultContent = await httpResult.Content.ReadAsStringAsync();
                    result = true;
                }
            }
            catch { }
            return result;
        }
    }
}

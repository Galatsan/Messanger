using MessengerData.Interfaces;
using MessengerData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessengerData.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private List<Message> messages;
        public MessageRepository()
        {
            messages = new List<Message>();
        }

        string IMessageRepository.Save(Message entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            messages.Add(entity);
            return entity.Id;
        }

        IEnumerable<Message> IMessageRepository.All()
        {
            return messages;
        }
    }
}

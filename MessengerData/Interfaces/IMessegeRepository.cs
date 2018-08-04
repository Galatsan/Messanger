using MessengerData.Models;
using System.Collections.Generic;

namespace MessengerData.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> All();

        string Save(Message entity);
    }
}

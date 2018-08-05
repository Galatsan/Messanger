using MessangerData.Models;
using System.Collections.Generic;

namespace MessangerData.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> All();

        string Save(Message entity);
    }
}

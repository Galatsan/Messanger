using MessengerBL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessengerBL.Interfaces
{
    public interface IMessageService
    {
        Task<string> SaveAsync(MessageDTO entity);
        Task<IEnumerable<MessageDTO>> AllAsync();
    }
}

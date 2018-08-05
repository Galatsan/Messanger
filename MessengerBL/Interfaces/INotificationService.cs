using MessangerBL.Models;
using System.Threading.Tasks;

namespace MessangerBL.Interfaces
{
    public interface INotificationService
    {
        Task<bool> SendMessageToNotificationServiceAsync(NotificationDTO notification);
    }
}

using MessengerCore.Models;

namespace MessengerData.Models
{
    public class Message : Entity
    {
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }
    }
}

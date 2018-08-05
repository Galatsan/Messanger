using System.ComponentModel.DataAnnotations;

namespace Messenger.Models
{
    public class CreateMessageViewModel
    {
        public string[] Recipients { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}

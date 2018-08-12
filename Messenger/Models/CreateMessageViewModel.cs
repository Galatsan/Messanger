using System.ComponentModel.DataAnnotations;

namespace Messenger.Models
{
    public class CreateMessageViewModel
    {
        [Required]
        public string[] Recipients { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}

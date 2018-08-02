namespace Messenger.Models
{
    public class IndexMessageViewModel
    {
        public string Id { get; set; }
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }
    }
}

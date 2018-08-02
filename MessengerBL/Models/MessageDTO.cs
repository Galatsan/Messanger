using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerBL.Models
{
    public class MessageDTO
    {
        public string Id { get; set; }
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }
    }
}

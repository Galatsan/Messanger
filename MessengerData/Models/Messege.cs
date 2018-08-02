using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerData.Models
{
    public class Messege
    {
        public string Id { get; set; }
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }
    }
}

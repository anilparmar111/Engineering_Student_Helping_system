using Esh.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime DateSend { get; set; }
        public bool IsRead { get; set; }
        public bool IsDelivered { get; set; }

        public string SenderUserID { get; set; }
        public string ReceiverUserID { get; set; }

        public ChatApplicationUser SenderUser { get; set; }
        public ChatApplicationUser ReceiverUser { get; set; }
    }
}
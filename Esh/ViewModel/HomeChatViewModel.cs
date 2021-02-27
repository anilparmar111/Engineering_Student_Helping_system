using Esh.Data;
using Esh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.ViewModel
{
    public class HomeChatViewModel
    {
        public IList<ChatApplicationUser> Users { get; set; }
        public IList<Message> MessagesBetween { get; set; }
        public ChatApplicationUser ReceiverUser { get; set; }
        public IDictionary<string, Message> LastMessageBetweenTwoUser { get; set; }
    }
}

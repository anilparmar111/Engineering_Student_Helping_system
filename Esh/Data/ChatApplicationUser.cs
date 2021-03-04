using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esh.Models;
using Microsoft.AspNetCore.Identity;

namespace Esh.Data
{
    // Add profile data for application users by adding properties to the ChatApplicationUser class
    public class ChatApplicationUser : IdentityUser
    {
        // For Messages
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
    }
}
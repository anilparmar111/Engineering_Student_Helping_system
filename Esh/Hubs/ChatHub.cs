using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Esh.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Console.Write($"Hello");
            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }
    }
}

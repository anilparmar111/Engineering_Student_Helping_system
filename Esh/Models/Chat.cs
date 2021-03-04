using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esh.Data;
using Microsoft.AspNetCore.Identity;
using Esh.Models;

namespace ChatApplication.Models
{
    public class Chat : Hub
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ChatApplicationUser> _usermanager;
        private readonly SignInManager<ChatApplicationUser> _signinmanager;

        public Chat(ApplicationDbContext context, UserManager<ChatApplicationUser> userManager, SignInManager<ChatApplicationUser> signInManager)
        {
            _usermanager = userManager;
            _signinmanager = signInManager;
            _context = context;
        }
        public async Task SendMessage(string message, string id)
        {
            ChatApplicationUser user = await _usermanager.FindByEmailAsync(Context.User.Identity.Name);
            try
            {
                var msg = new Message()
                {
                    Body = message,
                    DateSend = DateTime.Now,
                    SenderUserID = user.Id,
                    IsDelivered = false,
                    IsRead = false,
                    ReceiverUserID = id
                };
                _context.Messages.Add(msg);
                _context.SaveChanges();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            if (Context.User.Identity.IsAuthenticated)
            {
                await Clients.User(id).SendAsync("ReceiveMessage", id, message, false);
                await Clients.User(user.Id).SendAsync("ReceiveMessage", user.Id, message, true);
            }

        }
    }
}
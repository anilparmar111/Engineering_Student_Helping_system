﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Esh.Models;
using Microsoft.AspNetCore.Identity;
using Esh.Data;
using Esh.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace ChatApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ChatApplicationUser> userManager;
        private readonly SignInManager<ChatApplicationUser> signInManager;
        private readonly ApplicationDbContext chatApplicationDBContext;

        public HomeController(UserManager<ChatApplicationUser> userManager,
                             SignInManager<ChatApplicationUser> signInManager,
                             ApplicationDbContext chatApplicationDBContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.chatApplicationDBContext = chatApplicationDBContext;
        }

        [Route("Chat/ChatHome")]
        [Authorize]
        public async Task<IActionResult> ChatHome()
        {
            HomeChatViewModel homeChatViewModel = new HomeChatViewModel()
            {
                Users = (IList<ChatApplicationUser>)chatApplicationDBContext.Users.ToList(),
                MessagesBetween = null,
                ReceiverUser = null,
                LastMessageBetweenTwoUser = new Dictionary<string, Message>()
            };

            var loggedInUser = await userManager.GetUserAsync(User);

            for (int i = 0; i < homeChatViewModel.Users.Count; i++)
            {
                if (homeChatViewModel.Users[i] == loggedInUser)
                    homeChatViewModel.Users.Remove(homeChatViewModel.Users[i]);
            }
            for (int i = 0; i < homeChatViewModel.Users.Count; i++)
            {
                if (homeChatViewModel.Users[i] != loggedInUser)
                {
                    // fetch mesg between these 2 users.
                    var user2Id = homeChatViewModel.Users[i].Id;
                    var result = chatApplicationDBContext.Messages.Where(q =>
                    ((
                        q.ReceiverUserID == user2Id) && (q.SenderUserID == loggedInUser.Id))
                        || ((q.SenderUserID == user2Id) && (q.ReceiverUserID == loggedInUser.Id))
                    );

                    if (result != null)
                    {
                        homeChatViewModel.MessagesBetween = result.ToList();
                        if (homeChatViewModel.MessagesBetween.Count != 0)
                        {
                            homeChatViewModel.LastMessageBetweenTwoUser[user2Id] = homeChatViewModel.MessagesBetween[homeChatViewModel.MessagesBetween.Count - 1];
                        }
                        else
                        {
                            homeChatViewModel.LastMessageBetweenTwoUser[user2Id] = null;
                        }
                    }
                    else
                    {
                        homeChatViewModel.LastMessageBetweenTwoUser[user2Id] = null;
                    }
                }
            }
            return View(model: homeChatViewModel);
        }

        public async Task<IActionResult> FetchUser(string UserId)
        {
            HomeChatViewModel homeChatViewModel = new HomeChatViewModel()
            {
                Users = (IList<ChatApplicationUser>)chatApplicationDBContext.Users.ToList(),
                MessagesBetween = null,
                ReceiverUser = null,
                LastMessageBetweenTwoUser = new Dictionary<string, Message>()
            };
            var loggedInUser = await userManager.GetUserAsync(User);
            ViewBag.loginUser = loggedInUser.Id;



            for (int i = 0; i < homeChatViewModel.Users.Count; i++)
            {
                if (homeChatViewModel.Users[i] != loggedInUser)
                {
                    // fetch mesg between these 2 users.
                    var user2Id = homeChatViewModel.Users[i].Id;
                    var res = chatApplicationDBContext.Messages.Where(q =>
                    ((
                        q.ReceiverUserID == user2Id) && (q.SenderUserID == loggedInUser.Id))
                        || ((q.SenderUserID == user2Id) && (q.ReceiverUserID == loggedInUser.Id))
                    );

                    if (res != null)
                    {
                        homeChatViewModel.MessagesBetween = res.ToList();
                        if (homeChatViewModel.MessagesBetween.Count != 0)
                        {
                            homeChatViewModel.LastMessageBetweenTwoUser[user2Id] = homeChatViewModel.MessagesBetween[homeChatViewModel.MessagesBetween.Count - 1];
                        }
                        else
                        {
                            homeChatViewModel.LastMessageBetweenTwoUser[user2Id] = null;
                        }
                    }
                }
            }

            for (int i = 0; i < homeChatViewModel.Users.Count; i++)
            {
                if (homeChatViewModel.Users[i] == loggedInUser)
                    homeChatViewModel.Users.Remove(homeChatViewModel.Users[i]);
            }


            var result = chatApplicationDBContext.Messages.Where(q =>
                ((q.ReceiverUserID == UserId) && (q.SenderUserID == loggedInUser.Id))
                || ((q.SenderUserID == UserId) && (q.ReceiverUserID == loggedInUser.Id))
            );
            homeChatViewModel.MessagesBetween = result.ToList();

            ChatApplicationUser receiver = await userManager.FindByIdAsync(UserId);
            ViewBag.receiverId = receiver.Id;
            homeChatViewModel.ReceiverUser = receiver;
            return View("ChatHome", model: homeChatViewModel);
        }
    }
}
using Esh.Data;
using Esh.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Esh.Controllers
{
    [Authorize]
    public class Recommended : Controller
    {
        private readonly ILogger<Recommended> _logger;
        private readonly UserManager<ChatApplicationUser> _userManager;
        private readonly SignInManager<ChatApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        string userId = "";
        public Recommended(UserManager<ChatApplicationUser> userManager, SignInManager<ChatApplicationUser> signInManager, ApplicationDbContext dbContext, ILogger<Recommended> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            userId = _userManager.GetUserName(User);
            IEnumerable<Friend> friends = _context.Friends.Where(ob => ob.fid == userId || ob.uid == userId);
            HashSet<string> st = new HashSet<string>();
            foreach (Friend frd in friends)
            {
                //st.Add(frd.uid);
                if (frd.uid == userId)
                {
                    st.Add(frd.fid);
                }
                else
                {
                    st.Add(frd.uid);
                }
            }
            HashSet<string> recom = new HashSet<string>();
            string  myschool = _context.Eusers.FirstOrDefault(ob => ob.emailid == userId).Schoolname;
            IEnumerable<EshUser> user = _context.Eusers.Where(ob => ob.Schoolname == myschool);
            foreach(EshUser eu in user)
            {
                if(!st.Contains(eu.emailid) && eu.emailid!=userId)
                {
                    recom.Add(eu.emailid);
                }
            }
            foreach(string frd in st)
            {
                IEnumerable<Friend> friend_s_friend = _context.Friends.Where(ob => ob.fid == frd || ob.uid == frd);
                foreach (Friend mtfr in friend_s_friend)
                {
                    //st.Add(frd.uid);
                    if (mtfr.uid == frd)
                    {
                        if(!st.Contains(mtfr.fid) && mtfr.fid != userId)
                        {
                            recom.Add(mtfr.fid);
                        }
                        
                    }
                    else
                    {
                        if (!st.Contains(mtfr.uid) && mtfr.uid != userId)
                        {
                            recom.Add(mtfr.uid);
                        }
                    }
                }
            }
            List<EshUser> lst = new List<EshUser>();
            foreach (string str in recom)
            {
                lst.Add(_context.Eusers.FirstOrDefault(ob => ob.emailid == str));
            }
            return View(lst);
        }
    }
}

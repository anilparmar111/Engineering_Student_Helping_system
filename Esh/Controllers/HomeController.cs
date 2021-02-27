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
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ChatApplicationUser> _userManager;
        private readonly SignInManager<ChatApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        public HomeController(UserManager<ChatApplicationUser> userManager,SignInManager<ChatApplicationUser> signInManager,ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            
            string str= HttpContext.Session.GetString("AspNetCore.Identity.Application");
            if(str=="")
            {
                ViewBag.data = "notset";
            }
            else
            {
                string userId = _userManager.GetUserName(User);
                ViewBag.data = userId;
                HttpContext.Session.SetString("email",userId);
                HttpContext.Session.SetString("set", "1");
                HttpContext.Session.SetString("name", "ap");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Update(EshUser eshUser)
        {
            string userId = _userManager.GetUserName(User);
            EshUser eshUser1 = new EshUser();
            eshUser1 = eshUser;
            eshUser1.emailid = userId;
            _context.Add(eshUser1);
            _context.SaveChanges();
            return View("index");
        }

        public IActionResult Search()
        {
            string uname = ViewBag.Username;
            string userId = _userManager.GetUserName(User);
            EshUser findresult = _context.Eusers.FirstOrDefault(un => un.name == uname);
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult MyProfile()
        {
            return View();
        }
        public IActionResult Message()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult DemoMessage()
        {
            return View();
        }
    }
}

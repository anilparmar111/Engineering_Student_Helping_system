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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        string userId="";
        public HomeController(UserManager<IdentityUser> userManager,ApplicationDbContext dbContext)
        {
            _userManager = userManager;
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
                userId = _userManager.GetUserName(User);
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

        /*public IActionResult MyNetwork()
        {
            userId = _userManager.GetUserName(User);
            IEnumerable<Friend> friends = _context.Friends.Where(ob=> ob.fid==userId || ob.uid == userId);
            IEnumerable<Connection_Req> cr = _context.Connection_Reqs.Where(ob => ob.Recivername==userId);
            List<ReqUser> ruser=new List<ReqUser>();
            foreach(Connection_Req conr in cr)
            {
                EshUser eur = _context.Eusers.FirstOrDefault(ob => ob.emailid==conr.requestuser);
                ReqUser tmp = new ReqUser();
                tmp.name = eur.name;
                tmp.reqtime = conr.time;
                tmp.school = eur.Schoolname;
                tmp.uid = conr.requestuser;
                ruser.Add(tmp);
            }
            MNetwork mn = new MNetwork();
            mn.friends = friends;
            mn.requsers = ruser;
            return View(mn);
        }
        */
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

        public IActionResult Serch(string uname="")
        {
            //string uname = ViewBag.Username;
            //string userId = _userManager.GetUserName(User);
            //EshUser eu = _context.Eusers.FirstOrDefault(uname => uname.emailid == userId);
            userId = _userManager.GetUserName(User);
            EshUser findresult = _context.Eusers.FirstOrDefault(un => un.name == uname);
            if(findresult!=null)
            {
                ViewBag.find = "ok";
                Friend fr = _context.Friends.FirstOrDefault(ob => (ob.fid==findresult.emailid && ob.uid==userId) || (ob.fid == userId  && ob.uid == findresult.emailid));
                if(fr==null)
                {
                    ViewBag.friend = "not";
                    ViewBag.mail = findresult.emailid;
                }
                else
                {
                    ViewBag.friend = "friend";
                }
                
                //DateTime dt = DateTime.Now;
                //Connection_Req cr = new Connection_Req();
                return View(findresult);

            }
            else
            {
                ViewBag.find = uname;
                return View();
            }
            
        }

        public IActionResult Request_Connect(string fname)
        {
            Connection_Req cr = new Connection_Req();
            userId = _userManager.GetUserName(User);
            cr.time = DateTime.Now;
            cr.requestuser = userId;
            cr.Recivername = fname;
            _context.Add(cr);
            _context.SaveChanges();
            return Redirect("~/Home");
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
    }
}

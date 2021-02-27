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
        string userId="";
        public HomeController(UserManager<IdentityUser> userManager,ApplicationDbContext dbContext)
        public HomeController(UserManager<ChatApplicationUser> userManager,SignInManager<ChatApplicationUser> signInManager,ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbContext;
            
        }

        public IActionResult Index()
        {
            
            string str= HttpContext.Session.GetString("AspNetCore.Identity.Application");
                userId = _userManager.GetUserName(User);
                ViewBag.data = userId;
                HttpContext.Session.SetString("email",userId);
                HttpContext.Session.SetString("set", "1");
                EshUser esh = _context.Eusers.FirstOrDefault(obj => obj.emailid == userId);
                if (esh == null)
                {
                    HttpContext.Session.SetString("name", "Please Complate Details");
                }
                else
                {
                    HttpContext.Session.SetString("name", esh.name);
                }
            userId = _userManager.GetUserName(User);
            IEnumerable<Friend> friends = _context.Friends.Where(ob => ob.fid == userId || ob.uid == userId);
            HashSet<string> user=new HashSet<string>();
            foreach (Friend frd in friends)
            {
                EshUser eur = _context.Eusers.FirstOrDefault(ob => ob.emailid == frd.fid);
                user.Add(eur.emailid);
            }
            List<PostDataView> pv=new List<PostDataView>();
            foreach(PostData pd in _context.postDatas)
            {
                PostDataView tmp = new PostDataView();
                tmp.uid = userId;
                tmp.title = pd.title;
                tmp.uploadtime = pd.uploadtime;
                tmp.richtext = System.IO.File.ReadAllText(pd.richtext_file_path);
                pv.Add(tmp);
            }
            return View(pv);
            /*List<Post_Details> psd = new List<Post_Details>();
            IEnumerable<UsersPost> pst = _context.UsersPosts.Where(obj => 1==1);
            

            foreach(UsersPost pn in pst)
            {
                Post_Details pd = new Post_Details();
                pd.postid = pn.postid;
                pd.title = pn.title;
                pd.richtext= System.IO.File.ReadAllText(pn.richtext_file_path);
                pd.uploadtime = pn.uploadtime;
                psd.Add(pd);
            }*/
            //return View(psd);
            //EshUser my = _context.Eusers.FirstOrDefault(obj => obj.emailid == userId);
            //IEnumerable<EshUser> us = _context.Eusers.Where(obj => obj.Schoolname ==my.Schoolname);
            /*if (us != null)
            {
                foreach (EshUser eu in us)
                {
                    user.Add(eu.emailid);
                }
            }
            List<Post_Details> psd=new List<Post_Details>();
            foreach(string st in user)
            {
                IEnumerable<Post_New> pns = _context.Post_News.Where(obj => obj.uid == st);
                if (pns != null)
                {
                    foreach (Post_New pn in pns)
                    {
                        Post_Details pd = new Post_Details();
                        pd.postid = pn.postid;
                        pd.title = pn.title;
                        //uid,utime,rechtxt
                        pd.uid = pn.uid;
                        pd.uploadtime = pn.uploadtime;
                        pd.richtext = System.IO.File.ReadAllText(pn.richtext_file_path);
                        psd.Add(pd);
                    }
                }
            }*/
            //return View(psd);
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
        public IActionResult Search()
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
        public IActionResult DemoMessage()
        {
            return View();
        }
    }
}

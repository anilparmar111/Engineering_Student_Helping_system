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
using Esh.ViewModel;

namespace Esh.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ChatApplicationUser> _userManager;
        private readonly SignInManager<ChatApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        string userId="";
        public HomeController(UserManager<ChatApplicationUser> userManager, SignInManager<ChatApplicationUser> signInManager, ApplicationDbContext dbContext, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbContext;
            _logger = logger;
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
                    HttpContext.Session.SetString("name", "Please Fill Information");
                }
                else
                {
                    HttpContext.Session.SetString("name", esh.name);
                }
            userId = _userManager.GetUserName(User);
            IEnumerable<Friend> friends = _context.Friends.Where(ob => ob.fid == userId || ob.uid == userId);
            HashSet<string> st=new HashSet<string>();
            foreach(Friend frd in friends)
            {
                //st.Add(frd.uid);
                if(frd.uid==userId)
                {
                    st.Add(frd.fid);
                }
                else
                {
                    st.Add(frd.uid);
                }
            }
            HashSet<string> user=new HashSet<string>();
            foreach (Friend frd in friends)
            {
                EshUser eur = _context.Eusers.FirstOrDefault(ob => ob.emailid == frd.fid);
                user.Add(eur.emailid);
            }
            List<PostDataView> pv=new List<PostDataView>();
            //algo remaing and logic


            

            foreach(PostData pd in _context.postDatas)
            {
                if (st.Contains(pd.uid))
                {
                    PostDataView tmp = new PostDataView();
                    tmp.uid = userId;
                    tmp.title = pd.title;
                    tmp.uploadtime = pd.uploadtime;
                    tmp.richtext = System.IO.File.ReadAllText(pd.richtext_file_path);
                    pv.Add(tmp);
                }
            }
            _logger.LogInformation("Index Page Of Home Has Been Accessed");
            pv.Sort((ob1, ob2) => {
                if(ob1.uploadtime < ob2.uploadtime)
                {
                    return 1;
                }
                return 0;
            });
            return View(pv);
            
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy Page Of Home Has Been Accessed");
            return View();
        }

        public IActionResult tempforv()
        {
            return View();
        }

        public IActionResult Account()
        {
            string userId = _userManager.GetUserName(User);
            EshUser esu = _context.Eusers.FirstOrDefault(obj => obj.emailid == userId);
            _logger.LogInformation("Account Page Of Home Has Been Accessed");
            if (esu==null || esu.name=="")
            {
                ViewBag.notfill = "ok";
                return View();
            }
            else
            {
               
                userdata ud = new userdata();
                ud.EshUsers = esu;
                ud.pdvs = My_Post();
                return View("Userdata", ud);

            }
        }

        public List<PostDataView> My_Post()
        {
            string userId = _userManager.GetUserName(User);
            EshUser esu = _context.Eusers.FirstOrDefault(obj => obj.emailid == userId);

            IEnumerable<PostData> lsp = _context.postDatas.Where(obj => obj.uid == userId);
            List<PostDataView> pdv = new List<PostDataView>();
            foreach (PostData pd in lsp)
            {
                PostDataView tmp = new PostDataView();
                tmp.uid = userId;
                tmp.title = pd.title;
                tmp.uploadtime = pd.uploadtime;
                tmp.richtext = System.IO.File.ReadAllText(pd.richtext_file_path);
                tmp.Postid = pd.postid;
                pdv.Add(tmp);
            }
            return pdv;
        }


        public IActionResult Edit_Post(int id)
        {
            string userId = _userManager.GetUserName(User);
            PostData pd = _context.postDatas.FirstOrDefault(obj=> obj.postid==id && obj.uid==userId);
            if(pd==null)
            {
                ViewBag.error = "yes";
            }
            else
            {
                PostDataView pdv = new PostDataView();
                pdv.Postid = id;
                pdv.richtext= System.IO.File.ReadAllText(pd.richtext_file_path);
                pdv.title = pd.title;
                pdv.uid=pd.uid;
                pdv.uploadtime = pd.uploadtime;
                return View(pdv);
            }
            return View();
        }

        public IActionResult tmp()
        {
            return View();
        }

        public IActionResult Delete_Post(int id)
        {
            PostData pd = _context.postDatas.FirstOrDefault(obj => obj.postid == id);
            if(pd.uid== _userManager.GetUserName(User))
            {
                _context.postDatas.Remove(pd);
                _context.SaveChanges();
            }
            return Redirect("~/Home/My_Post");
        }


        public IActionResult Edit_Post_Save(int id,PostDataView pdv)
        {
            PostData pd = _context.postDatas.FirstOrDefault(obj => obj.postid==id);
            if(pd!=null && pd.uid== _userManager.GetUserName(User))
            {
                System.IO.File.WriteAllText(pd.richtext_file_path, pdv.richtext);
                pd.title = pdv.title;
                pd.uploadtime = DateTime.Now;
                _context.Update(pd);
                _context.SaveChanges();
               
            }
            return Redirect("~/Home/My_Post");
        }

        



        public IActionResult Update(EshUser eshUser)
        {
            string userId = _userManager.GetUserName(User);
            EshUser eshUser1 = new EshUser();
            eshUser1 = eshUser;
            eshUser1.emailid = userId;
            _context.Add(eshUser1);
            _context.SaveChanges();
            _logger.LogInformation("Update Page Of Home Has Been Accessed");
            return View("index");
        }


        public IActionResult Update_MyData(userdata ud)
        {
            EshUser eshUser = ud.EshUsers;
            string userId = _userManager.GetUserName(User);
            EshUser eshUser1 = _context.Eusers.FirstOrDefault(obj=>obj.emailid==userId);
            eshUser1.about = eshUser.about;
            eshUser1.designation = eshUser.designation;
            eshUser1.gender = eshUser.gender;
            eshUser1.name = eshUser.name;
            eshUser1.Persnal_Site_URL = eshUser.Persnal_Site_URL;
            eshUser1.Schoolname = eshUser.Schoolname;
            eshUser1.emailid = userId;
            _context.Update(eshUser1);
            _context.SaveChanges();
            _logger.LogInformation("Update Page Of Home Has Been Accessed");
            return View("index");
        }



        public IActionResult Serch(string uname="")
        {
            _logger.LogInformation("Search Page Of Home Has Been Accessed");
            //string uname = ViewBag.Username;
            //string userId = _userManager.GetUserName(User);
            //EshUser eu = _context.Eusers.FirstOrDefault(uname => uname.emailid == userId);
            userId = _userManager.GetUserName(User);
            EshUser findresult = _context.Eusers.FirstOrDefault(un => un.name == uname);
            if(findresult!=null)
            {
                ViewBag.find = "ok";
                Friend fr = _context.Friends.FirstOrDefault(ob => (ob.fid==findresult.emailid && ob.uid==userId) || (ob.fid == userId  && ob.uid == findresult.emailid));
                EshUser self = _context.Eusers.FirstOrDefault(un => un.emailid == userId);

                if (self.name == uname)
                {
                    return Redirect("~/Home");
                }

                if (fr == null)
                {
                    
                    Connection_Req ru = _context.Connection_Reqs.FirstOrDefault(ob => (ob.requestuser==userId &&  ob.Recivername== findresult.emailid) || (ob.requestuser==findresult.emailid && ob.Recivername == userId));
                    if (ru != null)
                    {
                        ViewBag.friend = "You Have Alrady Send Or Recive Connection Request";
                    }
                    else
                    {
                        ViewBag.friend = "not";
                        ViewBag.mail = findresult.emailid;
                    }
                }
                else
                {
                    ViewBag.friend = "You Both Are friends";
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

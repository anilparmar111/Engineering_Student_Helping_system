using Esh.Data;
using Esh.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Controllers
{
    public class MyNetwork : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        string userId = "";
        public MyNetwork(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _context = dbContext;

        }

        public IActionResult Index()
        {
            userId = _userManager.GetUserName(User);
            IEnumerable<Friend> friends = _context.Friends.Where(ob => ob.fid == userId || ob.uid == userId);
            IEnumerable<Connection_Req> cr = _context.Connection_Reqs.Where(ob => ob.Recivername == userId);
            List<EshUser> eshUsers=new List<EshUser>();
            List<ReqUser> ruser = new List<ReqUser>();
            foreach(Friend frd in friends)
            {
                EshUser eur = _context.Eusers.FirstOrDefault(ob => ob.emailid == frd.fid);
                eshUsers.Add(eur);
            }
            foreach (Connection_Req conr in cr)
            {
                EshUser eur = _context.Eusers.FirstOrDefault(ob => ob.emailid == conr.requestuser);
                ReqUser tmp = new ReqUser();
                tmp.name = eur.name;
                tmp.reqtime = conr.time;
                tmp.school = eur.Schoolname;
                tmp.designation = eur.designation;
                tmp.uid = conr.requestuser;
                ruser.Add(tmp);
            }
            MNetwork mn = new MNetwork();
            mn.friends = eshUsers;
            mn.requsers = ruser;
            return View(mn);
        }
        public IActionResult Accept(string fname)
        {
            Friend frd = new Friend();
            frd.fid = fname;
            frd.uid=_userManager.GetUserName(User);
            Connection_Req cnr = _context.Connection_Reqs.FirstOrDefault(obj => obj.Recivername== _userManager.GetUserName(User));
            _context.Remove(cnr);
            _context.Add(frd);
            _context.SaveChanges();
            return Redirect("~/Home");
        }
        public IActionResult Reject(string fname)
        {
            Connection_Req cnr = _context.Connection_Reqs.FirstOrDefault(obj => obj.Recivername == _userManager.GetUserName(User));
            _context.Remove(cnr);
            _context.SaveChanges();
            return Redirect("~/Home");
        }
    }
}

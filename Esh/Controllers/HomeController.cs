using Esh.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Esh.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                ViewBag.data = str;

            }
            return View();
        }

        public IActionResult Privacy()
        {
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
    }
}

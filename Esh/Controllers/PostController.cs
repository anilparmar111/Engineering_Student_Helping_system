﻿using Esh.Data;
using Esh.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using Newtonsoft.Json;

namespace Esh.Controllers
{
    public class PostController : Controller
    {
        private readonly UserManager<ChatApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        string userId = "";
        public PostController(UserManager<ChatApplicationUser> userManager, ApplicationDbContext dbContext, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _context = dbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post_Created(Create_Post cp)
        {
            string filepath;
            string folderPath = "Media/";
            folderPath += Guid.NewGuid().ToString() + "_" + RandomFileName(6);
            filepath = Path.Combine(_env.WebRootPath, folderPath);
            filepath += ".txt";
            System.IO.File.WriteAllText(filepath,cp.textfile);
            PostData up = new PostData();
            up.richtext_file_path = filepath;
            up.uploadtime = DateTime.Now;
            up.uid = _userManager.GetUserName(User);
            up.title = cp.title;
            _context.Add(up);
            _context.SaveChanges();
            return Redirect("~/Home");
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomFileName(int length)
        {
            const string chars = "abcdefghigklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

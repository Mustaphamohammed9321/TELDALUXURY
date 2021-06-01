using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYSERVICES.Controllers;
using THELDALUXURYECOMMERCE.Models;
using System.Net.Http;

namespace THELDALUXURYECOMMERCE.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _context;

        public AdminController(ILogger<AdminController> context)
        {
            _context = context;
        }


        //Admin Index Page
        //public IActionResult Index()
        //{
            //IEnumerable<mvcAdminUser> adminuserlist;
            //HttpResponseMessage response = GlobalVariables.GetAsync("AdminUser").Result;
            //adminuserlist = response.Content.ReadAsStringAsync<IEnumerable<mvcAdminUser>>().Result;
            //return View(adminuserlist);
        //}
        
        //Admin Index Page
        public IActionResult Login()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYSERVICES.Controllers;

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
        public IActionResult Index()
        {
            return View();
        }
        
        //Admin Index Page
        public IActionResult Login()
        {
            return View();
        }
    }
}

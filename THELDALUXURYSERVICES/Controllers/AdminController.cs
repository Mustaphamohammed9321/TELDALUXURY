using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Controllers
{
    public class AdminController : Controller
    {
        //Admin Index Page
        public IActionResult Index()
        {
            return View();
        }
    }
}

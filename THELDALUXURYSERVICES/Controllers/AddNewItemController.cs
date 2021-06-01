using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Controllers
{
    public class AddNewItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

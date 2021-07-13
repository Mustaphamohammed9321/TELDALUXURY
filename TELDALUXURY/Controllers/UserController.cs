using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TELDALUXURY.Controllers
{
    public class UserController : Controller
    {
       public ActionResult CreateUser()
        {
            return View();
        }

        
        // POST: Users
        public ActionResult Login()
        {

            return View();
        }
        
        // POST: Users
        public ActionResult SignUp()
        {

            return View();
        }
    }
}
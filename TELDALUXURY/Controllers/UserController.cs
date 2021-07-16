using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TELDALUXURY.Models;
using Dapper;

namespace TELDALUXURY.Controllers
{
    public class UserController : Controller
    {
       public ActionResult CreateUser()
        {
           return View();
       }


        [HttpPost]
        public ActionResult create(CreateUserLogin userlogin)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60061/api/Users/CreateUserAccount");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<CreateUserLogin>("userlogin", userlogin);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "User");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(userlogin);
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
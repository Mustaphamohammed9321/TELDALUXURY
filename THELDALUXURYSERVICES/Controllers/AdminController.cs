using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYSERVICES.Controllers;
using THELDALUXURYECOMMERCE.Models;
using System.Net.Http;
using WEBAPI.Models;
using THELDALUXURYECOMMERCE.Response;

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
        //    IEnumerable<mvcAdminUser> adminuserlist;
        //    HttpResponseMessage response = GlobalVariables.GetAsync("AdminUser").Result;
        //    adminuserlist = response.Content.ReadAsStringAsync<IEnumerable<mvcAdminUser>>().Result;
        //    return View(adminuserlist);
        //}

        //Admin Index Page
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(WEBAPI.Models.tb_Users user)
        {

            using (theldaluxuryEntities db = new WEBAPI.Models.theldaluxuryEntities())
            {
                var userDetails = db.tb_Users.Where(x => x.EmailAddress == user.EmailAddress && x.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    user.SigninErrorMessage = "Oops! You submitted an incorrect login details.";
                    return View("Index", user);
                }
                else
                {
                    //Session["ID"] = userModel.ID;
                    //Session["email"] = userModel.email;
                    return RedirectToAction("AdminPage", "Signin");
                }
            }


        }


        public ActionResult Logout()
        {
            //int id = (int)Session["ID"];
            //Session.Abandon();
            return RedirectToAction("Index", "Signin");
        }
    }
}

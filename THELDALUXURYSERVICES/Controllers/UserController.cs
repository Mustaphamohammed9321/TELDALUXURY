using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Response;
using WEBAPI.Models;
using System.Web;

namespace THELDALUXURYECOMMERCE.Controllers
{
    public class UserController : Controller
    {
        
        [HttpPost]
        public ActionResult UserLogin(WEBAPI.Models.tb_Users user)
        {
            using (theldaluxuryEntities db = new theldaluxuryEntities())
            {
                var userdetails = db.tb_Users.Where(x => (x.EmailAddress == user.EmailAddress
                && x.Password == user.Password) ||
                (x.UserName == user.UserName && x.Password == user.Password));

                //create a condition(if the userdetails is empty, throw an error message)
                //else, sign the user in with a session
                ResponseMessage response = new ResponseMessage();
                if (userdetails == null)
                {
                    //response.Message = "Incorrect login details, please try again";
                    user.ErrorMessage = "Incorrect login details, please try again";
                    return RedirectToAction("Index", user);
                }
                else
                {
                    //Session["Id"] = user.Id;
                    //Session["EmailAddress"] = user.EmailAddress;
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

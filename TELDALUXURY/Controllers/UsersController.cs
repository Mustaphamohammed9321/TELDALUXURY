using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TELDALUXURY.Models;
using TELDAMIN.Models;

namespace TELDALUXURY.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Userlogin(mvcUsers users)
        {
            theldaluxuryEntities db = new theldaluxuryEntities();
            using (db)
            {
                try
                {
                    var userDetails = db.tb_Users.Where(x => x.UserName == users.UserName && x.Password == users.Password).FirstOrDefault();
                    if (userDetails == null)
                    {
                        users.SigninErrorMessage = "Incorrect login details.";
                        return View("Login", users);
                    }
                    else
                    {
                        Session["Id"] = users.Id;
                        Session["EmailAddress"] = users.EmailAddress;
                        Session["FirstName"] = users.FirstName;
                        return RedirectToAction("Index", "Telda");
                    }
                }
                catch (Exception) {
                    //}
                    //else //pop an error message using sweet alert
                    //{
                    //    Response.Write("<script>alert('Cant connect to database, please contact admin on this kind of error')</script>");
                    //    //Response.Write("<script>swal('')</script>");
                    //    return RedirectToAction("Login","Users");
                    //}
                    return RedirectToAction("Error","Shared");
                }
            }
        }

        // POST: Users
        public ActionResult SignUp()
        {
            return View();
        }

        // GET: Users
        public ActionResult EditUser()   //havnt added view yet
        {
            return View();
        }
    }
}

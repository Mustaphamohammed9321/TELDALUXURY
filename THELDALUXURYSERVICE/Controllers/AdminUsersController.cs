using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;
using THELDALUXURYECOMMERCE.Data;
using THELDALUXURYSERVICE.Repository;
using System.Data;
using System.Data.Common;
//using WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace THELDALUXURYSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {
        private readonly AdminUserRepository adminuserRepo;

        public AdminUsersController(IDbConnection _DBCONNECTION)
        {
            adminuserRepo = new AdminUserRepository(_DBCONNECTION);
        }

        //admin Sign Up
        // POST api/<AdminUsersController>
        //[HttpPost]
        //public ActionResult CreateAdmin(tb_AdminUser adminuser)
        //{
            //using (AppDBContext db = new AppDBContext())
            //{
            //    var AdminDetails = db.adminusers.Where(x => x.UserName == adminuser.UserName && x.Password == adminuser.Password).FirstOrDefault();
            //    if (AdminDetails == null)
            //    {
            //        adminuser.SigninErrorMessage = "Oops! You submitted an incorrect login details.";
            //        return RedirectToAction("Index", adminuser);
            //    }
            //    else
            //    {
            //        //Session["ID"] = userModel.ID;
            //        //Session["email"] = userModel.email;
            //        return RedirectToAction("AdminPage", "Signin");
            //    }
            //}

            //try
            //{
            //    tb_AdminUser aU = new tb_AdminUser();
            //    if (aU.AdminId == 0 && ModelState.IsValid) 
            //    {
            //        aU.FirstName = adminuser.FirstName;
            //        aU.LastName = adminuser.LastName;
            //        aU.EmailAddress = adminuser.EmailAddress;
            //        aU.UserName = adminuser.UserName;
            //        aU.Password = adminuser.Password;
            //        aU.RoleId = adminuser.RoleId;
            //        adminuserRepo.CreateAccount(adminuser);
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        //}

        
        //Sign in for admin
        // GET api/<AdminUsersController>/5
        //[HttpGet("{UserName}/{Password}")]
        //public tb_AdminUser SignInAdmin(string username, string password)
        //{
        //    return adminuserRepo.AdminLogin(username,password);
        //}


        // GET: api/<AdminUsersController>
        [HttpGet]
        public IEnumerable<tb_AdminUser> Get()
        {
            return adminuserRepo.GetAll();
        }

        // GET api/<AdminUsersController>/5
        [HttpGet("{id}")]
        public tb_AdminUser Get(int id)
        {
            return adminuserRepo.GetAllById(id);
        }

        // POST api/<AdminUsersController>
        [HttpPost]
        public void Post([FromBody] tb_AdminUser adminuser)
        {
            if (ModelState.IsValid)
                adminuserRepo.Add(adminuser);
        }

        // PUT api/<AdminUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] tb_AdminUser adminuser)
        {
            adminuser.AdminId = id;
            if (ModelState.IsValid)
                adminuserRepo.Update(adminuser);
        }

        // DELETE api/<AdminUsersController>/5
        [HttpDelete("{id}")] 
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            tb_AdminUser ADMINUSER = new tb_AdminUser();
            var aUser = ADMINUSER.AdminId;

            if (id == aUser)
            {
                try
                {
                    adminuserRepo.Delete(id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}

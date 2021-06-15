using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYSERVICE.Repository;
using System.Data;
using THELDALUXURYECOMMERCE.Response;
using Microsoft.AspNetCore.Authorization;
using WEBAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace THELDALUXURYSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository userRepo;
        public UsersController(IDbConnection _DBCONNECTION)
        {
            userRepo = new UsersRepository(_DBCONNECTION);
        }


        // GET: api/<UsersController>
        [HttpGet("GetAllUser")]
        public IEnumerable<tb_Users> GetAllUser()
        {
            return userRepo.GetAllUser();
        }

        [HttpPost("UserLogin/")]
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
                    response.Message = "Incorrect login details, please try again";
                    return RedirectToAction("","");                
                }
                else
                {
                    //Session["Id"] = user.Id;
                    //Session["EmailAddress"] = user.EmailAddress;
                    return RedirectToAction("AdminPage", "Signin");
                }

            }
        }

        //logout Api
        [HttpPost("Users/Logout/")]
        public ActionResult Logout()
        {
            //int id = (int)Session["ID"];
            //Session.Abandon();
            return RedirectToAction("Index", "Signin");
        }


        //ADD NEW USER PHOTO
        [HttpPost("AddUserPhoto/")]
        public void PostUserPhoto([FromBody] tb_Users users)
        {
            if (ModelState.IsValid)
                userRepo.AddUserPhoto(users);
        }


        //UPDATE NEW USER PHOTO
        [HttpPut("UpdateUserPhoto/")]
        public void PutUserPhoto(int id, [FromBody] tb_Users user)
        {
            if (ModelState.IsValid)
                userRepo.UpdateUserPhoto(user);
        }


        // GET api/<UsersController>/5
        [HttpGet("GetUser/{id}")]
        public tb_Users GetUserById(int id)
        {
            return userRepo.GetAllById(id);
        }


        // GET api/<UsersController>/5
        [HttpGet("GetUpdatedUsers/")]
        public IEnumerable<tb_Users> GetUpdatedUsers()
        {
            return userRepo.GetUpdatedUser();
        }


        // POST api/<UsersController>
        [HttpPost("AddUser")]
        public void Post([FromBody] tb_Users user)
        {
            if (ModelState.IsValid)
                userRepo.Add(user);

        }


        // PUT api/<UsersController>/5
        [HttpPut("UpdateUser/{id}")]
        public ResponseMessage Put(int id, [FromBody] tb_Users user)
        {
            if (ModelState.IsValid)
                userRepo.Update(user);
            return new ResponseMessage { Status = "Success", Message = "User Record Updated Successfully" };
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("DeleteUser/{id}")]
        public void Delete(int id)
        {
            userRepo.Delete(id);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DAPPER_WEBAPI_TELDA.Repository;
using WEBAPI.Models;

using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DAPPER_WEBAPI_TELDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepo _userepo;
        public UsersController()
        {
            _userepo = new UsersRepo();
        }

        //Get: api/Firstname
        [HttpGet("GetUserName")]
        public IEnumerable<GetUserFirstName> GetUserFirstName()
        {
            if (ModelState.IsValid)
                return _userepo.GetUserNames().ToList();
            StatusCode(500, "Could not load data from database");
            return null;
        }


        // GET: api/Users
        [HttpGet("AllUsers")]
        public IEnumerable<mvcUsers> GetUsers()
        {
            if (ModelState.IsValid)
                return _userepo.GetUsers().ToList();
            StatusCode(500, "Could not load data from database");
            return null;
        }

        // GET: api/Users/5
        [HttpGet("Userlogin/{id}")]
        public mvcUsers GetUserById(int id)
        {
            return _userepo.GetUserById(id);
        }

        // POST: api/Users
        [HttpPost("CreateUserAccount")]
        public void CreateUserAccount([FromBody]CreateUserLogin user)
        {
            if (ModelState.IsValid)
                _userepo.CreateUserAccount(user);
            StatusCode(500, "Could not add new customer, please try again");
        }

        // PUT: api/Users/5
        [HttpPut("UpdateUser/{id}")]
        public void UpdateUser(int id, [FromBody]UpdateUserAccount updateuser)
        {
            if (ModelState.IsValid)
                _userepo.UpdateUserAccount(id, updateuser);
            StatusCode(500,"Update failed, please try again");
        }


        // DELETE: api/Users/5
        [HttpDelete("RemoveUserAccount/{id}")]
        public void Delete(int id)
        {
            try
            {
                _userepo.DeleteStaffLoginDetails(id);
                StatusCode(200,"Account deleted successfully");
            }
            catch (Exception ex)
            {
                StatusCode(500,ex.Message);
            }
        }










        //// GET: api/<CustomerController>
        //[HttpGet]
        //public IEnumerable<Customer> Get()
        //{
        //    if (ModelState.IsValid)
        //        return customer_repo.GetAllCustomers().ToList();
        //    NotFound("Could not load data from database");
        //    return null;
        //}

            //// GET api/<CustomerController>/5
            //[HttpGet("{id}")]
            //public Customer Get(int id)
            //{
            //    if (ModelState.IsValid)
            //        return customer_repo.GetCustomerById(id);
            //    //var response = BadRequest("Error Occured");
            //    return null;
            //}

            //// POST api/<CustomerController>
            //[HttpPost]
            //public void Post([FromBody] Customer customer)
            //{
            //   
            //}

           


        }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;
using THELDALUXURYECOMMERCE.Data;
using THELDALUXURYSERVICE.Repository;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace THELDALUXURYSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {

        //private readonly iAdminUserRepository _adminuserrepo;

    //constructor for the class AdminUsersController
        //public AdminUsersController(iAdminUserRepository adminuserrepo)
        //{
        //    _adminuserrepo = adminuserrepo;
        //}

        // GET: api/<AdminUsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<AdminUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminUsersController>/5
        [HttpDelete("{id}")] 
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
           
        }
    }
}

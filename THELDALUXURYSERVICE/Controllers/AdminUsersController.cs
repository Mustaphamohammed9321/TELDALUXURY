using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;
using THELDALUXURYECOMMERCE.Data;
using THELDALUXURYSERVICE.Repository;
using System.Data;

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

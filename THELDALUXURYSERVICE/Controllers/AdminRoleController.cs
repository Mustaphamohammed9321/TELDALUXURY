using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using THELDALUXURYSERVICE.Repository;
using WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace THELDALUXURYSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRoleController : ControllerBase
    {
        private readonly AdminRoleRepository adminroleRepo;
        public AdminRoleController(IDbConnection _DBCONNECTION)
        {
            adminroleRepo = new AdminRoleRepository(_DBCONNECTION);
        }


        // GET: api/<AdminRoleController>
        [HttpGet]
        public IEnumerable<tb_AdminRole> Get()
        {
            return adminroleRepo.GetAll(); ;
        }

        // GET api/<AdminRoleController>/5
        [HttpGet("{id}")]
        public tb_AdminRole Get(int id)
        {
            return adminroleRepo.GetAllById(id);
        }

        // POST api/<AdminRoleController>
        [HttpPost]
        public void Post([FromBody] tb_AdminRole adminrole)
        {
            if (ModelState.IsValid)
                adminroleRepo.Add(adminrole);
        }

        // PUT api/<AdminRoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] tb_AdminRole adminrole)
        {
            adminrole.AdminId = id;
            if (ModelState.IsValid)
                adminroleRepo.Update(adminrole);
        }

        // DELETE api/<AdminRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            adminroleRepo.Delete(id);
        }
    }
}

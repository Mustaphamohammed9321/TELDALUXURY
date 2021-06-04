using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;
using THELDALUXURYSERVICE.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace THELDALUXURYSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly StateRepository stateRepo;
        public StatesController(IDbConnection _DBCONNECTION)
        {
            stateRepo = new StateRepository(_DBCONNECTION);
        }
        
        // GET: api/<StatesController>
        [HttpGet]
        public IEnumerable<tb_State> Get()
        {
            return stateRepo.GetAll();
        }

        // GET api/<StatesController>/5
        [HttpGet("{id}")]
        public tb_State Get(int id)
        {
            return stateRepo.GetAllById(id);
        }

        // POST api/<StatesController>
        [HttpPost]
        public void Post([FromBody] tb_State state)
        {
            if (ModelState.IsValid)
                stateRepo.Add(state);
        }

        // PUT api/<StatesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] tb_State state)
        {
            state.StateId = id;
            if (ModelState.IsValid)
                stateRepo.Update(state);
        }

        // DELETE api/<StatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stateRepo.Delete(id);
            Response.StatusCode = 200;
        }
    }
}

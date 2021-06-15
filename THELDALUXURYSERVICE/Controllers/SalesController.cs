using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYSERVICE.Repository;
using System.Data;
using THELDALUXURYECOMMERCE.Models;
using THELDALUXURYECOMMERCE.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace THELDALUXURYSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesRepository tbsalesrepo;
        public SalesController(IDbConnection _DBCONNECTION)
        {
            tbsalesrepo = new SalesRepository(_DBCONNECTION);
        }

        public ResponseMessage response;

        // GET: api/<SalesController>
        [HttpGet]
        public IEnumerable<tb_Sales> Get()
        {
                return tbsalesrepo.GetAll();               
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public tb_Sales Get(int id)
        {
            return tbsalesrepo.GetAllById(id);
        }

        // POST api/<SalesController>
        [HttpPost]
        public ResponseMessage Post([FromBody] tb_Sales sales)
        {
            if (ModelState.IsValid)
            {
                tbsalesrepo.Add(sales);
                return new ResponseMessage { Status = "Success", Message = "Record Added Succesfully" };
            }
            else
            {
                return new ResponseMessage { Status = "Error", Message = "Oops! This Sales Wasn't Recorded, Please Try Again" };
            }
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public ResponseMessage Put(int id, [FromBody] tb_Sales sales)
        { 
            //compare if id is found in the database
            if (ModelState.IsValid)
            {
                tbsalesrepo.Update(sales);
                return new ResponseMessage { Status = "Success", Message = "Updated Successfully" };
            }
            else
            {
                return new ResponseMessage { Status = "Error", Message = "Oops! This Sales Wasn't Updated, Please Try Again" };
            }
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public ResponseMessage Delete(int id, tb_Sales sales)
        {
            if (id == sales.SalesId) 
            {
                tbsalesrepo.Delete(id);
                return new ResponseMessage { Status = "Success", Message = "Record Deleted Successfully" };
            }
            else
            {
                return new ResponseMessage { Status = "Error", Message = "Oops! Can't find a record with this Id, please try again" };
            }
        }
    }
}
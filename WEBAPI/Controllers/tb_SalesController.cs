using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class tb_SalesController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_Sales
        public IQueryable<tb_Sales> Gettb_Sales()
        {
            return db.tb_Sales;
        }

        // GET: api/tb_Sales/5
        [ResponseType(typeof(tb_Sales))]
        public IHttpActionResult Gettb_Sales(int id)
        {
            tb_Sales tb_Sales = db.tb_Sales.Find(id);
            if (tb_Sales == null)
            {
                return NotFound();
            }

            return Ok(tb_Sales);
        }

        // PUT: api/tb_Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_Sales(int id, tb_Sales tb_Sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Sales.SalesId)
            {
                return BadRequest();
            }

            db.Entry(tb_Sales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_SalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tb_Sales
        [ResponseType(typeof(tb_Sales))]
        public IHttpActionResult Posttb_Sales(tb_Sales tb_Sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_Sales.Add(tb_Sales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_Sales.SalesId }, tb_Sales);
        }

        // DELETE: api/tb_Sales/5
        [ResponseType(typeof(tb_Sales))]
        public IHttpActionResult Deletetb_Sales(int id)
        {
            tb_Sales tb_Sales = db.tb_Sales.Find(id);
            if (tb_Sales == null)
            {
                return NotFound();
            }

            db.tb_Sales.Remove(tb_Sales);
            db.SaveChanges();

            return Ok(tb_Sales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_SalesExists(int id)
        {
            return db.tb_Sales.Count(e => e.SalesId == id) > 0;
        }
    }
}
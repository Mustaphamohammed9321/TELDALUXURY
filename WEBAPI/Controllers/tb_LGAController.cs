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
using DAPPER_WEBAPI_TELDA.Models;

namespace DAPPER_WEBAPI_TELDA.Controllers
{
    public class tb_LGAController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_LGA
        public IQueryable<tb_LGA> Gettb_LGA()
        {
            return db.tb_LGA;
        }

        // GET: api/tb_LGA/5
        [ResponseType(typeof(tb_LGA))]
        public IHttpActionResult Gettb_LGA(int id)
        {
            tb_LGA tb_LGA = db.tb_LGA.Find(id);
            if (tb_LGA == null)
            {
                return NotFound();
            }

            return Ok(tb_LGA);
        }

        // PUT: api/tb_LGA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_LGA(int id, tb_LGA tb_LGA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_LGA.lgaID)
            {
                return BadRequest();
            }

            db.Entry(tb_LGA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_LGAExists(id))
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

        // POST: api/tb_LGA
        [ResponseType(typeof(tb_LGA))]
        public IHttpActionResult Posttb_LGA(tb_LGA tb_LGA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_LGA.Add(tb_LGA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_LGA.lgaID }, tb_LGA);
        }

        // DELETE: api/tb_LGA/5
        [ResponseType(typeof(tb_LGA))]
        public IHttpActionResult Deletetb_LGA(int id)
        {
            tb_LGA tb_LGA = db.tb_LGA.Find(id);
            if (tb_LGA == null)
            {
                return NotFound();
            }

            db.tb_LGA.Remove(tb_LGA);
            db.SaveChanges();

            return Ok(tb_LGA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_LGAExists(int id)
        {
            return db.tb_LGA.Count(e => e.lgaID == id) > 0;
        }
    }
}
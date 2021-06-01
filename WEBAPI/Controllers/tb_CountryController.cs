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
    public class tb_CountryController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_Country
        public IQueryable<tb_Country> Gettb_Country()
        {
            return db.tb_Country;
        }

        // GET: api/tb_Country/5
        [ResponseType(typeof(tb_Country))]
        public IHttpActionResult Gettb_Country(int id)
        {
            tb_Country tb_Country = db.tb_Country.Find(id);
            if (tb_Country == null)
            {
                return NotFound();
            }

            return Ok(tb_Country);
        }

        // PUT: api/tb_Country/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_Country(int id, tb_Country tb_Country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Country.countryId)
            {
                return BadRequest();
            }

            db.Entry(tb_Country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_CountryExists(id))
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

        // POST: api/tb_Country
        [ResponseType(typeof(tb_Country))]
        public IHttpActionResult Posttb_Country(tb_Country tb_Country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_Country.Add(tb_Country);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_Country.countryId }, tb_Country);
        }

        // DELETE: api/tb_Country/5
        [ResponseType(typeof(tb_Country))]
        public IHttpActionResult Deletetb_Country(int id)
        {
            tb_Country tb_Country = db.tb_Country.Find(id);
            if (tb_Country == null)
            {
                return NotFound();
            }

            db.tb_Country.Remove(tb_Country);
            db.SaveChanges();

            return Ok(tb_Country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_CountryExists(int id)
        {
            return db.tb_Country.Count(e => e.countryId == id) > 0;
        }
    }
}
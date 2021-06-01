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
    public class ViewCountriesController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/ViewCountries
        public IQueryable<ViewCountry> GetViewCountries()
        {
            return db.ViewCountries;
        }

        // GET: api/ViewCountries/5
        [ResponseType(typeof(ViewCountry))]
        public IHttpActionResult GetViewCountry(int id)
        {
            ViewCountry viewCountry = db.ViewCountries.Find(id);
            if (viewCountry == null)
            {
                return NotFound();
            }

            return Ok(viewCountry);
        }

        // PUT: api/ViewCountries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViewCountry(int id, ViewCountry viewCountry)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != viewCountry.countryId)
            {
                return BadRequest();
            }

            db.Entry(viewCountry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewCountryExists(id))
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

        // POST: api/ViewCountries
        [ResponseType(typeof(ViewCountry))]
        public IHttpActionResult PostViewCountry(ViewCountry viewCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViewCountries.Add(viewCountry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viewCountry.countryId }, viewCountry);
        }

        // DELETE: api/ViewCountries/5
        [ResponseType(typeof(ViewCountry))]
        public IHttpActionResult DeleteViewCountry(int id)
        {
            ViewCountry viewCountry = db.ViewCountries.Find(id);
            if (viewCountry == null)
            {
                return NotFound();
            }

            db.ViewCountries.Remove(viewCountry);
            db.SaveChanges();

            return Ok(viewCountry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViewCountryExists(int id)
        {
            return db.ViewCountries.Count(e => e.countryId == id) > 0;
        }
    }
}
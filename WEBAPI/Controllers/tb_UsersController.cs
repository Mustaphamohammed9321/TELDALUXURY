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
    public class tb_UsersController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_Users
        public IQueryable<tb_Users> Gettb_Users()
        {
            return db.tb_Users;
        }

        // GET: api/tb_Users/5
        [ResponseType(typeof(tb_Users))]
        public IHttpActionResult Gettb_Users(int id)
        {
            tb_Users tb_Users = db.tb_Users.Find(id);
            if (tb_Users == null)
            {
                return NotFound();
            }

            return Ok(tb_Users);
        }

        // PUT: api/tb_Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_Users(int id, tb_Users tb_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Users.Id)
            {
                return BadRequest();
            }

            db.Entry(tb_Users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_UsersExists(id))
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

        // POST: api/tb_Users
        [ResponseType(typeof(tb_Users))]
        public IHttpActionResult Posttb_Users(tb_Users tb_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_Users.Add(tb_Users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_Users.Id }, tb_Users);
        }

        // DELETE: api/tb_Users/5
        [ResponseType(typeof(tb_Users))]
        public IHttpActionResult Deletetb_Users(int id)
        {
            tb_Users tb_Users = db.tb_Users.Find(id);
            if (tb_Users == null)
            {
                return NotFound();
            }

            db.tb_Users.Remove(tb_Users);
            db.SaveChanges();

            return Ok(tb_Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_UsersExists(int id)
        {
            return db.tb_Users.Count(e => e.Id == id) > 0;
        }
    }
}
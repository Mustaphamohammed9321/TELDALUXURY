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
    public class tb_StateController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_State
        public IQueryable<tb_State> Gettb_State()
        {
            return db.tb_State;
        }

        // GET: api/tb_State/5
        [ResponseType(typeof(tb_State))]
        public IHttpActionResult Gettb_State(int id)
        {
            tb_State tb_State = db.tb_State.Find(id);
            if (tb_State == null)
            {
                return NotFound();
            }

            return Ok(tb_State);
        }

        // PUT: api/tb_State/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_State(int id, tb_State tb_State)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_State.StateId)
            {
                return BadRequest();
            }

            db.Entry(tb_State).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_StateExists(id))
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

        // POST: api/tb_State
        [ResponseType(typeof(tb_State))]
        public IHttpActionResult Posttb_State(tb_State tb_State)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_State.Add(tb_State);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_State.StateId }, tb_State);
        }

        // DELETE: api/tb_State/5
        [ResponseType(typeof(tb_State))]
        public IHttpActionResult Deletetb_State(int id)
        {
            tb_State tb_State = db.tb_State.Find(id);
            if (tb_State == null)
            {
                return NotFound();
            }

            db.tb_State.Remove(tb_State);
            db.SaveChanges();

            return Ok(tb_State);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_StateExists(int id)
        {
            return db.tb_State.Count(e => e.StateId == id) > 0;
        }
    }
}
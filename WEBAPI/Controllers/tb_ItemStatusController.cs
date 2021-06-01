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
    public class tb_ItemStatusController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_ItemStatus
        public IQueryable<tb_ItemStatus> Gettb_ItemStatus()
        {
            return db.tb_ItemStatus;
        }

        // GET: api/tb_ItemStatus/5
        [ResponseType(typeof(tb_ItemStatus))]
        public IHttpActionResult Gettb_ItemStatus(int id)
        {
            tb_ItemStatus tb_ItemStatus = db.tb_ItemStatus.Find(id);
            if (tb_ItemStatus == null)
            {
                return NotFound();
            }

            return Ok(tb_ItemStatus);
        }

        // PUT: api/tb_ItemStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_ItemStatus(int id, tb_ItemStatus tb_ItemStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_ItemStatus.ItemId)
            {
                return BadRequest();
            }

            db.Entry(tb_ItemStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_ItemStatusExists(id))
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

        // POST: api/tb_ItemStatus
        [ResponseType(typeof(tb_ItemStatus))]
        public IHttpActionResult Posttb_ItemStatus(tb_ItemStatus tb_ItemStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_ItemStatus.Add(tb_ItemStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_ItemStatus.ItemId }, tb_ItemStatus);
        }

        // DELETE: api/tb_ItemStatus/5
        [ResponseType(typeof(tb_ItemStatus))]
        public IHttpActionResult Deletetb_ItemStatus(int id)
        {
            tb_ItemStatus tb_ItemStatus = db.tb_ItemStatus.Find(id);
            if (tb_ItemStatus == null)
            {
                return NotFound();
            }

            db.tb_ItemStatus.Remove(tb_ItemStatus);
            db.SaveChanges();

            return Ok(tb_ItemStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_ItemStatusExists(int id)
        {
            return db.tb_ItemStatus.Count(e => e.ItemId == id) > 0;
        }
    }
}
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
    public class tb_ErrorLogController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_ErrorLog
        public IQueryable<tb_ErrorLog> Gettb_ErrorLog()
        {
            return db.tb_ErrorLog;
        }

        // GET: api/tb_ErrorLog/5
        [ResponseType(typeof(tb_ErrorLog))]
        public IHttpActionResult Gettb_ErrorLog(int id)
        {
            tb_ErrorLog tb_ErrorLog = db.tb_ErrorLog.Find(id);
            if (tb_ErrorLog == null)
            {
                return NotFound();
            }

            return Ok(tb_ErrorLog);
        }

        // PUT: api/tb_ErrorLog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_ErrorLog(int id, tb_ErrorLog tb_ErrorLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_ErrorLog.logId)
            {
                return BadRequest();
            }

            db.Entry(tb_ErrorLog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_ErrorLogExists(id))
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

        // POST: api/tb_ErrorLog
        [ResponseType(typeof(tb_ErrorLog))]
        public IHttpActionResult Posttb_ErrorLog(tb_ErrorLog tb_ErrorLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_ErrorLog.Add(tb_ErrorLog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_ErrorLog.logId }, tb_ErrorLog);
        }

        // DELETE: api/tb_ErrorLog/5
        [ResponseType(typeof(tb_ErrorLog))]
        public IHttpActionResult Deletetb_ErrorLog(int id)
        {
            tb_ErrorLog tb_ErrorLog = db.tb_ErrorLog.Find(id);
            if (tb_ErrorLog == null)
            {
                return NotFound();
            }

            db.tb_ErrorLog.Remove(tb_ErrorLog);
            db.SaveChanges();

            return Ok(tb_ErrorLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_ErrorLogExists(int id)
        {
            return db.tb_ErrorLog.Count(e => e.logId == id) > 0;
        }
    }
}
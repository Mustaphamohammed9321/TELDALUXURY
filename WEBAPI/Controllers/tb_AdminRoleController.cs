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
    public class tb_AdminRoleController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_AdminRole
        public IQueryable<tb_AdminRole> Gettb_AdminRole()
        {
            return db.tb_AdminRole;
        }

        // GET: api/tb_AdminRole/5
        [ResponseType(typeof(tb_AdminRole))]
        public IHttpActionResult Gettb_AdminRole(int id)
        {
            tb_AdminRole tb_AdminRole = db.tb_AdminRole.Find(id);
            if (tb_AdminRole == null)
            {
                return NotFound();
            }

            return Ok(tb_AdminRole);
        }

        // PUT: api/tb_AdminRole/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_AdminRole(int id, tb_AdminRole tb_AdminRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_AdminRole.RoleId)
            {
                return BadRequest();
            }

            db.Entry(tb_AdminRole).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_AdminRoleExists(id))
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

        // POST: api/tb_AdminRole
        [ResponseType(typeof(tb_AdminRole))]
        public IHttpActionResult Posttb_AdminRole(tb_AdminRole tb_AdminRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_AdminRole.Add(tb_AdminRole);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_AdminRole.RoleId }, tb_AdminRole);
        }

        // DELETE: api/tb_AdminRole/5
        [ResponseType(typeof(tb_AdminRole))]
        public IHttpActionResult Deletetb_AdminRole(int id)
        {
            tb_AdminRole tb_AdminRole = db.tb_AdminRole.Find(id);
            if (tb_AdminRole == null)
            {
                return NotFound();
            }

            db.tb_AdminRole.Remove(tb_AdminRole);
            db.SaveChanges();

            return Ok(tb_AdminRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_AdminRoleExists(int id)
        {
            return db.tb_AdminRole.Count(e => e.RoleId == id) > 0;
        }
    }
}
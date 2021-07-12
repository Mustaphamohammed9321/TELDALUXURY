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
    public class tb_AdminUserController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_AdminUser
        public IQueryable<tb_AdminUser> Gettb_AdminUser()
        {
            return db.tb_AdminUser;
        }

        // GET: api/tb_AdminUser/5
        [ResponseType(typeof(tb_AdminUser))]
        public IHttpActionResult Gettb_AdminUser(int id)
        {
            tb_AdminUser tb_AdminUser = db.tb_AdminUser.Find(id);
            if (tb_AdminUser == null)
            {
                return NotFound();
            }

            return Ok(tb_AdminUser);
        }

        // PUT: api/tb_AdminUser/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_AdminUser(int id, tb_AdminUser tb_AdminUser)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != tb_AdminUser.AdminId)
            {
                return BadRequest();
            }

            db.Entry(tb_AdminUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_AdminUserExists(id))
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

        // POST: api/tb_AdminUser
        [ResponseType(typeof(tb_AdminUser))]
        public IHttpActionResult Posttb_AdminUser(tb_AdminUser tb_AdminUser)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.tb_AdminUser.Add(tb_AdminUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_AdminUser.AdminId }, tb_AdminUser);
        }

        // DELETE: api/tb_AdminUser/5
        [ResponseType(typeof(tb_AdminUser))]
        public IHttpActionResult Deletetb_AdminUser(int id)
        {
            tb_AdminUser tb_AdminUser = db.tb_AdminUser.Find(id);
            if (tb_AdminUser == null)
            {
                return NotFound();
            }

            db.tb_AdminUser.Remove(tb_AdminUser);
            db.SaveChanges();

            return Ok(tb_AdminUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_AdminUserExists(int id)
        {
            return db.tb_AdminUser.Count(e => e.AdminId == id) > 0;
        }
    }
}
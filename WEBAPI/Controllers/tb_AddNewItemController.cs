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
    public class tb_AddNewItemController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_AddNewItem
        public IQueryable<tb_AddNewItem> Gettb_AddNewItem()
        {
            return db.tb_AddNewItem;
        }

        // GET: api/tb_AddNewItem/5
        [ResponseType(typeof(tb_AddNewItem))]
        public IHttpActionResult Gettb_AddNewItem(int id)
        {
            tb_AddNewItem tb_AddNewItem = db.tb_AddNewItem.Find(id);
            if (tb_AddNewItem == null)
            {
                return NotFound();
            }

            return Ok(tb_AddNewItem);
        }

        // PUT: api/tb_AddNewItem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_AddNewItem(int id, tb_AddNewItem tb_AddNewItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_AddNewItem.ItemId)
            {
                return BadRequest();
            }

            db.Entry(tb_AddNewItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_AddNewItemExists(id))
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

        // POST: api/tb_AddNewItem
        [ResponseType(typeof(tb_AddNewItem))]
        public IHttpActionResult Posttb_AddNewItem(tb_AddNewItem tb_AddNewItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_AddNewItem.Add(tb_AddNewItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_AddNewItem.ItemId }, tb_AddNewItem);
        }

        // DELETE: api/tb_AddNewItem/5
        [ResponseType(typeof(tb_AddNewItem))]
        public IHttpActionResult Deletetb_AddNewItem(int id)
        {
            tb_AddNewItem tb_AddNewItem = db.tb_AddNewItem.Find(id);
            if (tb_AddNewItem == null)
            {
                return NotFound();
            }

            db.tb_AddNewItem.Remove(tb_AddNewItem);
            db.SaveChanges();

            return Ok(tb_AddNewItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_AddNewItemExists(int id)
        {
            return db.tb_AddNewItem.Count(e => e.ItemId == id) > 0;
        }
    }
}
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
    public class tb_ItemController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_Item
        public IQueryable<tb_Item> Gettb_Item()
        {
            return db.tb_Item;
        }

        // GET: api/tb_Item/5
        [ResponseType(typeof(tb_Item))]
        public IHttpActionResult Gettb_Item(int id)
        {
            tb_Item tb_Item = db.tb_Item.Find(id);
            if (tb_Item == null)
            {
                return NotFound();
            }

            return Ok(tb_Item);
        }

        // PUT: api/tb_Item/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_Item(int id, tb_Item tb_Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Item.ItemId)
            {
                return BadRequest();
            }

            db.Entry(tb_Item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_ItemExists(id))
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

        // POST: api/tb_Item
        [ResponseType(typeof(tb_Item))]
        public IHttpActionResult Posttb_Item(tb_Item tb_Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_Item.Add(tb_Item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_Item.ItemId }, tb_Item);
        }

        // DELETE: api/tb_Item/5
        [ResponseType(typeof(tb_Item))]
        public IHttpActionResult Deletetb_Item(int id)
        {
            tb_Item tb_Item = db.tb_Item.Find(id);
            if (tb_Item == null)
            {
                return NotFound();
            }

            db.tb_Item.Remove(tb_Item);
            db.SaveChanges();

            return Ok(tb_Item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_ItemExists(int id)
        {
            return db.tb_Item.Count(e => e.ItemId == id) > 0;
        }
    }
}
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
    public class tb_ItemCategoryController : ApiController
    {
        private theldaluxuryEntities db = new theldaluxuryEntities();

        // GET: api/tb_ItemCategory
        public IQueryable<tb_ItemCategory> Gettb_ItemCategory()
        {
            return db.tb_ItemCategory;
        }

        // GET: api/tb_ItemCategory/5
        [ResponseType(typeof(tb_ItemCategory))]
        public IHttpActionResult Gettb_ItemCategory(int id)
        {
            tb_ItemCategory tb_ItemCategory = db.tb_ItemCategory.Find(id);
            if (tb_ItemCategory == null)
            {
                return NotFound();
            }

            return Ok(tb_ItemCategory);
        }

        // PUT: api/tb_ItemCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_ItemCategory(int id, tb_ItemCategory tb_ItemCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_ItemCategory.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(tb_ItemCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_ItemCategoryExists(id))
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

        // POST: api/tb_ItemCategory
        [ResponseType(typeof(tb_ItemCategory))]
        public IHttpActionResult Posttb_ItemCategory(tb_ItemCategory tb_ItemCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_ItemCategory.Add(tb_ItemCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_ItemCategory.CategoryId }, tb_ItemCategory);
        }

        // DELETE: api/tb_ItemCategory/5
        [ResponseType(typeof(tb_ItemCategory))]
        public IHttpActionResult Deletetb_ItemCategory(int id)
        {
            tb_ItemCategory tb_ItemCategory = db.tb_ItemCategory.Find(id);
            if (tb_ItemCategory == null)
            {
                return NotFound();
            }

            db.tb_ItemCategory.Remove(tb_ItemCategory);
            db.SaveChanges();

            return Ok(tb_ItemCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_ItemCategoryExists(int id)
        {
            return db.tb_ItemCategory.Count(e => e.CategoryId == id) > 0;
        }
    }
}
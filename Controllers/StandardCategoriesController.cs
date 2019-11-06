using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CookieHunterProject.Models;

namespace CookieHunterProject.Controllers
{
    public class StandardCategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StandardCategories
        public IQueryable<StandardCategory> GetStandardCategories()
        {
            return db.StandardCategories;
        }

        // GET: api/StandardCategories/5
        [ResponseType(typeof(StandardCategory))]
        public async Task<IHttpActionResult> GetStandardCategory(int id)
        {
            StandardCategory standardCategory = await db.StandardCategories.FindAsync(id);
            if (standardCategory == null)
            {
                return NotFound();
            }

            return Ok(standardCategory);
        }

        // PUT: api/StandardCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStandardCategory(int id, StandardCategory standardCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != standardCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(standardCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardCategoryExists(id))
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

        // POST: api/StandardCategories
        [ResponseType(typeof(StandardCategory))]
        public async Task<IHttpActionResult> PostStandardCategory(StandardCategory standardCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StandardCategories.Add(standardCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = standardCategory.Id }, standardCategory);
        }

        // DELETE: api/StandardCategories/5
        [ResponseType(typeof(StandardCategory))]
        public async Task<IHttpActionResult> DeleteStandardCategory(int id)
        {
            StandardCategory standardCategory = await db.StandardCategories.FindAsync(id);
            if (standardCategory == null)
            {
                return NotFound();
            }

            db.StandardCategories.Remove(standardCategory);
            await db.SaveChangesAsync();

            return Ok(standardCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StandardCategoryExists(int id)
        {
            return db.StandardCategories.Count(e => e.Id == id) > 0;
        }
    }
}
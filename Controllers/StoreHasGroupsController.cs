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
    public class StoreHasGroupsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StoreHasGroups
        public IQueryable<StoreHasGroups> GetStoreHasGroups()
        {
            return db.StoreHasGroups;
        }

        // GET: api/StoreHasGroups/5
        [ResponseType(typeof(StoreHasGroups))]
        public async Task<IHttpActionResult> GetStoreHasGroups(int id)
        {
            StoreHasGroups storeHasGroups = await db.StoreHasGroups.FindAsync(id);
            if (storeHasGroups == null)
            {
                return NotFound();
            }

            return Ok(storeHasGroups);
        }

        // PUT: api/StoreHasGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStoreHasGroups(int id, StoreHasGroups storeHasGroups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storeHasGroups.Id)
            {
                return BadRequest();
            }

            db.Entry(storeHasGroups).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreHasGroupsExists(id))
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

        // POST: api/StoreHasGroups
        [ResponseType(typeof(StoreHasGroups))]
        public async Task<IHttpActionResult> PostStoreHasGroups(StoreHasGroups storeHasGroups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StoreHasGroups.Add(storeHasGroups);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = storeHasGroups.Id }, storeHasGroups);
        }

        // DELETE: api/StoreHasGroups/5
        [ResponseType(typeof(StoreHasGroups))]
        public async Task<IHttpActionResult> DeleteStoreHasGroups(int id)
        {
            StoreHasGroups storeHasGroups = await db.StoreHasGroups.FindAsync(id);
            if (storeHasGroups == null)
            {
                return NotFound();
            }

            db.StoreHasGroups.Remove(storeHasGroups);
            await db.SaveChangesAsync();

            return Ok(storeHasGroups);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreHasGroupsExists(int id)
        {
            return db.StoreHasGroups.Count(e => e.Id == id) > 0;
        }
    }
}
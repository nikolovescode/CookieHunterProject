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
    public class GroupACategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GroupACategories
        public IQueryable<GroupACategory> GetGroupACategories()
        {
            return db.GroupACategories;
        }
        public IEnumerable<GroupACategory> Get(int storeId)
        {
            var groups = db.GroupACategories.Where(GroupACategory => GroupACategory.StoreId.Equals(storeId));
            return groups;
        }

        // GET: api/GroupACategories/5
        [ResponseType(typeof(GroupACategory))]
        public async Task<IHttpActionResult> GetGroupACategory(int id)
        {
            GroupACategory groupACategory = await db.GroupACategories.FindAsync(id);
            if (groupACategory == null)
            {
                return NotFound();
            }

            return Ok(groupACategory);
        }

        // PUT: api/GroupACategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroupACategory(int id, GroupACategory groupACategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupACategory.Id)
            {
                return BadRequest();
            }

            db.Entry(groupACategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupACategoryExists(id))
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

        // POST: api/GroupACategories
        [ResponseType(typeof(GroupACategory))]
        public async Task<IHttpActionResult> PostGroupACategory(GroupACategory groupACategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupACategories.Add(groupACategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groupACategory.Id }, groupACategory);
        }

        // DELETE: api/GroupACategories/5
        [ResponseType(typeof(GroupACategory))]
        public async Task<IHttpActionResult> DeleteGroupACategory(int id)
        {
            GroupACategory groupACategory = await db.GroupACategories.FindAsync(id);
            if (groupACategory == null)
            {
                return NotFound();
            }

            db.GroupACategories.Remove(groupACategory);
            await db.SaveChangesAsync();

            return Ok(groupACategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupACategoryExists(int id)
        {
            return db.GroupACategories.Count(e => e.Id == id) > 0;
        }
    }
}
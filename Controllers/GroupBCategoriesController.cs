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
    public class GroupBCategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GroupBCategories
        public IQueryable<GroupBCategory> GetGroupBCategories()
        {
            return db.GroupBCategories;
        }

        public IEnumerable<GroupBCategory> Get(int storeId)
        {
            var groups = db.GroupBCategories.Where(GroupBCategory => GroupBCategory.StoreId.Equals(storeId));
            return groups;
        }

        // GET: api/GroupBCategories/5
        [ResponseType(typeof(GroupBCategory))]
        public async Task<IHttpActionResult> GetGroupBCategory(int id)
        {
            GroupBCategory groupBCategory = await db.GroupBCategories.FindAsync(id);
            if (groupBCategory == null)
            {
                return NotFound();
            }

            return Ok(groupBCategory);
        }

        // PUT: api/GroupBCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroupBCategory(int id, GroupBCategory groupBCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupBCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(groupBCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupBCategoryExists(id))
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

        // POST: api/GroupBCategories
        [ResponseType(typeof(GroupBCategory))]
        public async Task<IHttpActionResult> PostGroupBCategory(GroupBCategory groupBCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupBCategories.Add(groupBCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groupBCategory.Id }, groupBCategory);
        }

        // DELETE: api/GroupBCategories/5
        [ResponseType(typeof(GroupBCategory))]
        public async Task<IHttpActionResult> DeleteGroupBCategory(int id)
        {
            GroupBCategory groupBCategory = await db.GroupBCategories.FindAsync(id);
            if (groupBCategory == null)
            {
                return NotFound();
            }

            db.GroupBCategories.Remove(groupBCategory);
            await db.SaveChangesAsync();

            return Ok(groupBCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupBCategoryExists(int id)
        {
            return db.GroupBCategories.Count(e => e.Id == id) > 0;
        }
    }
}
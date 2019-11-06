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
    public class GroupCCategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GroupCCategories
        public IQueryable<GroupCCategory> GetGroupCCategories()
        {
            return db.GroupCCategories;
        }

        public IEnumerable<GroupCCategory> Get(int storeId)
        {
            var groups = db.GroupCCategories.Where(GroupCCategory => GroupCCategory.StoreId.Equals(storeId));
            return groups;
        }

        // GET: api/GroupCCategories/5
        [ResponseType(typeof(GroupCCategory))]
        public async Task<IHttpActionResult> GetGroupCCategory(int id)
        {
            GroupCCategory groupCCategory = await db.GroupCCategories.FindAsync(id);
            if (groupCCategory == null)
            {
                return NotFound();
            }

            return Ok(groupCCategory);
        }

        // PUT: api/GroupCCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroupCCategory(int id, GroupCCategory groupCCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupCCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(groupCCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupCCategoryExists(id))
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

        // POST: api/GroupCCategories
        [ResponseType(typeof(GroupCCategory))]
        public async Task<IHttpActionResult> PostGroupCCategory(GroupCCategory groupCCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupCCategories.Add(groupCCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groupCCategory.Id }, groupCCategory);
        }

        // DELETE: api/GroupCCategories/5
        [ResponseType(typeof(GroupCCategory))]
        public async Task<IHttpActionResult> DeleteGroupCCategory(int id)
        {
            GroupCCategory groupCCategory = await db.GroupCCategories.FindAsync(id);
            if (groupCCategory == null)
            {
                return NotFound();
            }

            db.GroupCCategories.Remove(groupCCategory);
            await db.SaveChangesAsync();

            return Ok(groupCCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupCCategoryExists(int id)
        {
            return db.GroupCCategories.Count(e => e.Id == id) > 0;
        }
    }
}
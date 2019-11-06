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
    public class UserHasSubscriptionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserHasSubscriptions
        public IQueryable<UserHasSubscription> GetUserHasSubscriptions()
        {
            return db.UserHasSubscriptions;
        }

        public IEnumerable<Store> Get(string userhasroleemail)
        {
            var storeIds = db.UserHasSubscriptions
                .Where(userHasSubscriptions => userHasSubscriptions.UserHasRoleEmail == userhasroleemail)
                .Select(userHasSubscriptions => userHasSubscriptions.StoreId)
                .ToList();

            var stores = db.Stores
                .Where(store => storeIds.Contains(store.Id))
                .ToList();
  
            List<Store> storeList = new List<Store>();
 
            foreach (var s in stores)
            {
                var resultItem = new Store()
                {
                    Id = s.Id,
                    Name = s.Name
                };
                storeList.Add(resultItem);
            }
            return storeList;
        }

        // GET: api/UserHasSubscriptions/5
        [ResponseType(typeof(UserHasSubscription))]
        public async Task<IHttpActionResult> GetUserHasSubscription(int id)
        {
            UserHasSubscription userHasSubscription = await db.UserHasSubscriptions.FindAsync(id);
            if (userHasSubscription == null)
            {
                return NotFound();
            }

            return Ok(userHasSubscription);
        }

        // PUT: api/UserHasSubscriptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserHasSubscription(int id, UserHasSubscription userHasSubscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userHasSubscription.Id)
            {
                return BadRequest();
            }

            db.Entry(userHasSubscription).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHasSubscriptionExists(id))
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

        // POST: api/UserHasSubscriptions
        [ResponseType(typeof(UserHasSubscription))]
        public async Task<IHttpActionResult> PostUserHasSubscription(UserHasSubscription userHasSubscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserHasSubscriptions.Add(userHasSubscription);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userHasSubscription.Id }, userHasSubscription);
        }

        // DELETE: api/UserHasSubscriptions/5
        [ResponseType(typeof(UserHasSubscription))]
        public async Task<IHttpActionResult> DeleteUserHasSubscription(int id)
        {
            UserHasSubscription userHasSubscription = await db.UserHasSubscriptions.FindAsync(id);
            if (userHasSubscription == null)
            {
                return NotFound();
            }

            db.UserHasSubscriptions.Remove(userHasSubscription);
            await db.SaveChangesAsync();

            return Ok(userHasSubscription);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserHasSubscriptionExists(int id)
        {
            return db.UserHasSubscriptions.Count(e => e.Id == id) > 0;
        }
    }
}
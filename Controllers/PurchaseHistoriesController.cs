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
    public class PurchaseHistoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PurchaseHistories
        public IQueryable<PurchaseHistory> GetPurchaseHistories()
        {
            return db.PurchaseHistories;
        }
        public IEnumerable<PurchaseHistory> Get(int storeId, string userHasRoleEmail)
        {
            var phs = db.PurchaseHistories.Where(PurchaseHistory => PurchaseHistory.StoreId.Equals(storeId) & PurchaseHistory.UserHasRoleEmail.Equals(userHasRoleEmail));
            return phs;
        }
        // GET: api/PurchaseHistories/5
        [ResponseType(typeof(PurchaseHistory))]
        public async Task<IHttpActionResult> GetPurchaseHistory(int id)
        {
            PurchaseHistory purchaseHistory = await db.PurchaseHistories.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            return Ok(purchaseHistory);
        }

        // PUT: api/PurchaseHistories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchaseHistory(int id, PurchaseHistory purchaseHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseHistory.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseHistory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseHistoryExists(id))
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

        // POST: api/PurchaseHistories
        [ResponseType(typeof(PurchaseHistory))]
        public async Task<IHttpActionResult> PostPurchaseHistory(PurchaseHistory purchaseHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseHistories.Add(purchaseHistory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchaseHistory.Id }, purchaseHistory);
        }

        // DELETE: api/PurchaseHistories/5
        [ResponseType(typeof(PurchaseHistory))]
        public async Task<IHttpActionResult> DeletePurchaseHistory(int id)
        {
            PurchaseHistory purchaseHistory = await db.PurchaseHistories.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            db.PurchaseHistories.Remove(purchaseHistory);
            await db.SaveChangesAsync();

            return Ok(purchaseHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseHistoryExists(int id)
        {
            return db.PurchaseHistories.Count(e => e.Id == id) > 0;
        }
    }
}
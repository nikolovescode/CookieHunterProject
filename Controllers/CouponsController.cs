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
    public class CouponsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Coupons
        public IQueryable<Coupon> GetCoupons()
        {
            return db.Coupons;
        }

        public IEnumerable<Item> Get(int standardCategoryId, int storeId)
        {
            var coup = db.Coupons
                     .Where(w => w.StandardCategoryId.Equals(standardCategoryId) && w.StoreId.Equals(storeId) && w.LastDate >= DateTime.Now)
                     .Select(w => w.ItemId)
                .ToList();

            var items = db.Items
                .Where(item => coup.Contains(item.Id))
                .ToList();

            List<Item> itemList = new List<Item>();

            foreach (var i in items)
            {
                var resultItem = new Item()
                {
                    Id = i.Id,
                    Name = i.Name,
                    StoreId = i.StoreId,
                    StandardCategoryId = i.StandardCategoryId

                };
                itemList.Add(resultItem);
            }

            return itemList;
        }
        // GET: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public async Task<IHttpActionResult> GetCoupon(int id)
        {
            Coupon coupon = await db.Coupons.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }

            return Ok(coupon);
        }

        // PUT: api/Coupons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoupon(int id, Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coupon.Id)
            {
                return BadRequest();
            }

            db.Entry(coupon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
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

        // POST: api/Coupons
        [ResponseType(typeof(Coupon))]
        public async Task<IHttpActionResult> PostCoupon(Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coupons.Add(coupon);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = coupon.Id }, coupon);
        }

        // DELETE: api/Coupons/5
        [ResponseType(typeof(Coupon))]
        public async Task<IHttpActionResult> DeleteCoupon(int id)
        {
            Coupon coupon = await db.Coupons.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }

            db.Coupons.Remove(coupon);
            await db.SaveChangesAsync();

            return Ok(coupon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CouponExists(int id)
        {
            return db.Coupons.Count(e => e.Id == id) > 0;
        }
    }
}
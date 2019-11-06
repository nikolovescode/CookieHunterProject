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
    public class UserHasRolesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserHasRoles
        public IQueryable<UserHasRole> GetUserHasRoles()
        {
            return db.UserHasRoles;
        }

        public IEnumerable<UserHasRole> Get(string email)
        {
            var uhrs = from u in db.UserHasRoles
                         select u;
            if (!String.IsNullOrEmpty(email))
            {
                uhrs = db.UserHasRoles.Where(UserHasRole => UserHasRole.Email.Equals(email));
            }
            return uhrs;
        }
        // GET: api/UserHasRoles/5
        [ResponseType(typeof(UserHasRole))]
        public async Task<IHttpActionResult> GetUserHasRole(int id)
        {
            UserHasRole userHasRole = await db.UserHasRoles.FindAsync(id);
            if (userHasRole == null)
            {
                return NotFound();
            }

            return Ok(userHasRole);
        }

        // PUT: api/UserHasRoles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserHasRole(int id, UserHasRole userHasRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userHasRole.Id)
            {
                return BadRequest();
            }

            db.Entry(userHasRole).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHasRoleExists(id))
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

        // POST: api/UserHasRoles
        [ResponseType(typeof(UserHasRole))]
        public async Task<IHttpActionResult> PostUserHasRole(UserHasRole userHasRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserHasRoles.Add(userHasRole);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userHasRole.Id }, userHasRole);
        }

        // DELETE: api/UserHasRoles/5
        [ResponseType(typeof(UserHasRole))]
        public async Task<IHttpActionResult> DeleteUserHasRole(int id)
        {
            UserHasRole userHasRole = await db.UserHasRoles.FindAsync(id);
            if (userHasRole == null)
            {
                return NotFound();
            }

            db.UserHasRoles.Remove(userHasRole);
            await db.SaveChangesAsync();

            return Ok(userHasRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserHasRoleExists(int id)
        {
            return db.UserHasRoles.Count(e => e.Id == id) > 0;
        }
    }
}
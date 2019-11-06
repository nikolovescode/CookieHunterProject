using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CookieHunterProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.Store> Stores { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.StandardCategory> StandardCategories { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.GroupACategory> GroupACategories { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.GroupBCategory> GroupBCategories { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.GroupCCategory> GroupCCategories { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.StoreHasGroups> StoreHasGroups { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.Coupon> Coupons { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.PurchaseHistory> PurchaseHistories { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.UserHasRole> UserHasRoles { get; set; }

        public System.Data.Entity.DbSet<CookieHunterProject.Models.UserHasSubscription> UserHasSubscriptions { get; set; }
    }
}
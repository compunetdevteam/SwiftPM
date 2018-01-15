using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SwiftPM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class SwiftPmDb : IdentityDbContext<ApplicationUser>
    {
        public SwiftPmDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SwiftPmDb Create()
        {
            return new SwiftPmDb();
        }

        public System.Data.Entity.DbSet<SwiftPMModel.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<SwiftPMModel.Department> Departments { get; set; }
    }
}
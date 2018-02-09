using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SwiftPMModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SwiftPM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; internal set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string  FullName { get { return FirstName + "" + LastName; } }

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
        //public SwiftPmDb()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}
        public SwiftPmDb()
          : base("SwiftPmDb", throwIfV1Schema: false)
        {
        }

        public static SwiftPmDb Create()
        {
            return new SwiftPmDb();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>().ToTable("User");

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");

        }

        public DbSet<SwiftPMModel.Project> Projects { get; set; }

        public DbSet<SwiftPMModel.Department> Departments { get; set; }

        public DbSet<SwiftPMModel.Staff> Staffs { get; set; }

        public DbSet<SwiftPMModel.Unit> Units { get; set; }

        public DbSet<SwiftPMModel.TaskActivity> TaskActivities { get; set; }

        public DbSet<SwiftPMModel.ModuleTask> ModuleTasks { get; set; }

        public DbSet<SwiftPMModel.AssignedTask> AssignedTasks { get; set; }

        public DbSet<SwiftPMModel.ProjectModule> ProjectModules { get; set; }

        public DbSet<SwiftPMModel.ModuleTaskIssue> ModuleTaskIssues { get; set; }

        public DbSet<AssignStaffToDept> AssignStaffToDepts { get; set; }
    }
}
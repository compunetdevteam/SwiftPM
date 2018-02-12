namespace SwiftPM.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SwiftPM.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SwiftPM.Models.SwiftPmDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(SwiftPmDb context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "HR"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "HR" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "CompanyIT"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "CompanyIT" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "CEO"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "CEO" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Director"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Director" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "HOD"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "HOD" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Supervisor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Supervisor" };

                manager.Create(role);
            }


            if (!context.Roles.Any(r => r.Name == "Staff"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Staff" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@SwiftPm.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@SwiftPm.com",
                    Email = "admin@SwiftPm.com",
                    EmailConfirmed = true,
                    FirstName = "App Admin",
                    LastName = "SwiftPM",

                };

                manager.Create(user, "admin12345");
                manager.AddToRole(user.Id, "AppAdmin");
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }

}
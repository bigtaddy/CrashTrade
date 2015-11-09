using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResourceManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ResourceManagerContext context)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("Member"))
                {
                    roleManager.Create(new IdentityRole("Member"));
                }

                var user = new ApplicationUser();
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.Email = "admin@admin.com";
                user.UserName = "admin@admin.com";
                user.JoinDate = DateTime.Now.Date;

                var userResult = userManager.Create(user, "Admin123456");

                if (userResult.Succeeded)
                {
                    var userAdmin = userManager.FindByName("admin@admin.com");
                    userManager.SetLockoutEnabled(userAdmin.Id, false);
                    userAdmin.EmailConfirmed = true;
                    userManager.Update(userAdmin);
                    userManager.AddToRole(userAdmin.Id, "Admin");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

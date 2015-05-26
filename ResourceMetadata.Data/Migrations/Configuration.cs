using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResourceMetadata.Models;

namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResourceManagerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResourceManagerEntities context)
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
                user.Email = "admin1@admin.com";
                user.UserName = "admin1@admin.com";

                var userResult = userManager.Create(user, "Admin123456789");

                if (userResult.Succeeded)
                {
                    //var user = userManager.FindByName("admin@marlabs.com");
                    userManager.AddToRole<ApplicationUser>(user.Id, "Admin");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //context.Users.Add(new ApplicationUser { Email = "abc@yahoo.com", Password = "Marlabs" });
            //context.SaveChanges();           
        }
    }
}

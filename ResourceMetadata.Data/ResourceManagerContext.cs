using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceMetadata.Models;
using ResourceMetadata.Data.Configurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;

namespace ResourceMetadata.Data
{
    public class ResourceManagerEntities : IdentityDbContext<ApplicationUser>
    {
        public ResourceManagerEntities()
            : base("CrashT")
        {

        }


        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<ImageInfo> ImageInfos { get; set; }

        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CarModelConfiguration());
            modelBuilder.Configurations.Add(new ManufactureConfiguration());
            modelBuilder.Configurations.Add(new AdvertConfiguration());

            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
        }
    }

    public class ResourceManagerDbInitializer : CreateDatabaseIfNotExists<ResourceManagerEntities>
    {
        protected override void Seed(ResourceManagerEntities context)
        {
        /*    try
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

                var userResult = userManager.Create(user, "admin");

                if (userResult.Succeeded)
                {
                    //var user = userManager.FindByName("admin@marlabs.com");
                    userManager.AddToRole<ApplicationUser>(user.Id, "Admin");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }*/

            //context.Users.Add(new ApplicationUser { Email = "abc@yahoo.com", Password = "Marlabs" });
            //context.SaveChanges();  
               
        }
            
    }


}

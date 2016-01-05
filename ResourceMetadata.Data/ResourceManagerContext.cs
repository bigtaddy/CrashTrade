using System;
using ResourceMetadata.Models;
using ResourceMetadata.Data.Configurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace ResourceMetadata.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("CrashT", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<SparePartAdvert> SparePartAdverts { get; set; }
        public DbSet<ImageInfo> ImageInfos { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CarModelConfiguration());
            modelBuilder.Configurations.Add(new ManufactureConfiguration());
            modelBuilder.Configurations.Add(new AdvertConfiguration());
            modelBuilder.Configurations.Add(new SparePartAdvertConfiguration());

            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            //base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUserLogin>()
           .ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityUserRole>()
            .ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("AspNetUserClaims");
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityRole>()
               .ToTable("AspNetRoles");
        }

        public class ResourceManagerDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext context)
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
}

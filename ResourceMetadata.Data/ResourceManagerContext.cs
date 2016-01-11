using System;
using ResourceMetadata.Models;
using ResourceMetadata.Data.Configurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Collections;
using System.Collections.Generic;

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

    }

    public class ResourceManagerDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
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

                var manufactureModels = new List<Manufacture>();

                manufactureModels.Add(new Manufacture
                {
                    Name = "Audi",
                    CarModels = new List<CarModel> {
                            new CarModel {Name = "100"},
                                new CarModel { Name = "A2"},
                               new CarModel { Name = "A3"},
                               new CarModel { Name = "A4"},
                              new CarModel {  Name = "A5"},
                              new CarModel {  Name = "A6"},
                              new CarModel {  Name = "A8"},
                              new CarModel {  Name = "Coupe"},
                             new CarModel {   Name = "Q7"},
                                new CarModel {Name = "R8"},
                            new CarModel { Name = "TT"}
                        }
                });
                manufactureModels.Add(new Manufacture
                {
                    Name = "Bmw",
                    CarModels = new List<CarModel> {
                        
                            new CarModel {Name = "1xx series"},
                            new CarModel {Name = "2xx series"},
                            new CarModel {Name = "3xx series"},
                            new CarModel {Name = "5xx series"},
                            new CarModel {Name = "6xx series"},
                            new CarModel {Name = "7xx series"},
                            new CarModel {Name = "8xx series"},
                            new CarModel {Name = "Z1"},
                            new CarModel {Name = "Z3"},
                            new CarModel {Name = "Z4"},
                          new CarModel {Name = "Z8"},
                          new CarModel {Name = "X3"},
                          new CarModel {Name = "X5"},
                         new CarModel {Name = "TT"}
                        }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Alfa Romeo",
                    CarModels = new List<CarModel> {
                            new CarModel {   Name = "145"},
                             new CarModel {   Name = "146"},
                            new CarModel {   Name = "CL147"},
                            new CarModel {   Name = "155"},
                            new CarModel {   Name = "156"},
                            new CarModel {   Name = "164"},
                            new CarModel {   Name = "166"},
                            new CarModel {   Name = "Brera"},
                            new CarModel {   Name = "GT Coupe"},
                            new CarModel {   Name = "GTV"},
                            new CarModel {   Name = "Spider"}
                               }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "AC"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Acura",
                    CarModels = new List<CarModel> {
                            new CarModel {Name = "CL"},
                            new CarModel {Name = "CSX"},
                            new CarModel {Name = "EL"},
                            new CarModel {Name = "Integra (RSX)"},
                            new CarModel {Name = "Integra Coupe (RSX Coupe)"},
                            new CarModel {Name = "MDX"},
                            new CarModel {Name = "NSX"},
                            new CarModel {Name = "NSX-T"},
                            new CarModel {Name = "RDX"},
                            new CarModel {Name = "RL"},
                            new CarModel {Name = "RSX"},
                             new CarModel {Name = "SLX"},
                            new CarModel {Name = "TL"},
                             new CarModel {Name = "TSX"},
                            new CarModel {Name = "ZDX"}
                            }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Aston Martin"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Bentley",
                    CarModels = new List<CarModel> {

                          new CarModel { Name = "Arnage"},
                           new CarModel {Name = "Azure"},
                            new CarModel {Name = "Brooklands"},
                            new CarModel {Name = "Continental"},
                            new CarModel {Name = "Mulsanne"},
                            new CarModel {Name = "Turbo R"}
                    }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Brilliance",
                    CarModels = new List<CarModel> {

                          new CarModel { Name = "M1"},
                           new CarModel {Name = "M2"}
          
                    }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Buick",
                    CarModels = new List<CarModel> {
                          new CarModel { Name = "Century"},
                           new CarModel {Name = "LaCrosse"},
                            new CarModel {Name = "Lucerne"},
                            new CarModel {Name = "Skylark Coupe"},
                            new CarModel {Name = "Park Avenue"},
                            new CarModel {Name = "Rainer"},                        
                          new CarModel { Name = "Regal"},
                           new CarModel {Name = "Terraza"},
                            new CarModel {Name = "Rivera"},
                            new CarModel {Name = "Roadmaster"},
                            new CarModel {Name = "Skylark"},
                            new CarModel {Name = "Sedan"},
                               new CarModel {Name = "Allante"}              
                             }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Cadillac"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Chery",
                    CarModels = new List<CarModel> {
                          new CarModel { Name = "A15"},
                           new CarModel {Name = "Arrizo 7"},
                            new CarModel {Name = "Bonus 3 (E3/A19)"},
                            new CarModel {Name = "Bonus (A13)"},
                            new CarModel {Name = "Fora (A21)"},
                            new CarModel {Name = "Turbo R"},
                             new CarModel { Name = "IndiS (S18D)"},
                           new CarModel {Name = "Kimo (A1)"},
                            new CarModel {Name = "M11 (A3)"},
                            new CarModel {Name = "QQ6 (S21)"},
                            new CarModel {Name = "Tiggo 5"},
                            new CarModel {Name = "Tiggo (T11)"},
                            new CarModel {Name = "Very (T11)"}

                    }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Chrysler",
                    CarModels = new List<CarModel> {
                          new CarModel { Name = "200"},
                           new CarModel {Name = "300C"},
                            new CarModel {Name = "300C SRT8"},
                            new CarModel {Name = "300M"},
                            new CarModel {Name = "Cirrus"},
                            new CarModel {Name = "Concorde"},
                           new CarModel { Name = "Crossfire"},
                           new CarModel {Name = "Fifth Avenue"},
                            new CarModel {Name = "Intrepid"},
                            new CarModel {Name = "Le Baron"},
                            new CarModel {Name = "LHS"},
                            new CarModel {Name = "Neon"},    
                            new CarModel { Name = "NEW Yorker"},
                           new CarModel {Name = "Pacifica"},
                            new CarModel {Name = "Prowler"},
                            new CarModel {Name = "PT Cruiser"},
                            new CarModel {Name = "Sebring"},
                            new CarModel {Name = "Stratus"},
                            new CarModel {Name = "Town & Country"},
                            new CarModel {Name = "Voyager"}
                    }
                });


                manufactureModels.Add(new Manufacture
                {
                    Name = "Cizeta"
                });


                manufactureModels.Add(new Manufacture
                {
                    Name = "Citroen",
                    CarModels = new List<CarModel> {
                          new CarModel { Name = "Berlingo"},
                           new CarModel {Name = "C1"},
                            new CarModel {Name = "C2"},
                            new CarModel {Name = "C3"},
                            new CarModel {Name = "C4"},
                            new CarModel {Name = "C5"},
                             new CarModel { Name = "C8"},
                           new CarModel {Name = "Evasion"},
                            new CarModel {Name = "Saxo"},
                            new CarModel {Name = "Xantia"},
                            new CarModel {Name = "XM"},
                            new CarModel {Name = "Jumpy"},
                             new CarModel { Name = "C-Elysee"},
                           new CarModel {Name = "Jumper"}
                           
                    }
                });


                manufactureModels.Add(new Manufacture
                {
                    Name = "Dacia"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Daewoo",
                    CarModels = new List<CarModel> {
                          new CarModel { Name = "Matiz"},
                           new CarModel {Name = "Nexia"}
      
                    }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Daihatsu"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Daimler"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Dodge",
                    CarModels = new List<CarModel> {
                          new CarModel { Name = "Avenger"},
                           new CarModel {Name = "Caravan"},
                            new CarModel {Name = "Intrepid"},
                            new CarModel {Name = "Nitro"},
                            new CarModel {Name = "Viper"},
                            new CarModel {Name = "Caliber"},
                                   new CarModel { Name = "Charger"},
                           new CarModel {Name = "Magnum"},
                            new CarModel {Name = "Ram"},
                            new CarModel {Name = "Durango"},
                            new CarModel {Name = "Neon"},
                            new CarModel {Name = "Stratus"},
                    }
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Ferrari"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Fiat"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Ford"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Geely"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "GMC"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Great Wall"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Honda"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Hummer"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Hyundai"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Infiniti"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Isuzu"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Jaguar"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Jeep"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Kia"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Lancia"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Land Rover"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Lexus"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Lifan"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Lincoln"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Mazda"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Mercedes"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Mini"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Mitsubishi"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Nissan"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Oldsmobile"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Opel"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Peugeot"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Plymouth"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Pontiac"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Porsche"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Rover"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Saab"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Scion"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Seat"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Skoda"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Smart"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "SsangYong"
                });

                manufactureModels.Add(new Manufacture
                {
                    Id = 1,
                    Name = "Subaru"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Suzuki"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Toyota"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Volkswagen"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Volvo"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "ВАЗ"
                });

                manufactureModels.Add(new Manufacture
                {
                    Name = "Chevrolet",
                    CarModels = new List<CarModel> {
                          new CarModel { Name = "Aveo"},
                           new CarModel {Name = "Blazer"},
                            new CarModel {Name = "Camaro"},
                            new CarModel {Name = "Captiva"},
                            new CarModel {Name = "Cobalt"},
                            new CarModel {Name = "Corvette"},
                             new CarModel {Name = "Cruze"},
                              new CarModel {Name = "Epica"},
                               new CarModel {Name = "Evanda"},
                                new CarModel {Name = "Express"},
                                 new CarModel {Name = "Lacetti"},
                                  new CarModel {Name = "Lanos"},
                                   new CarModel {Name = "Niva"},
                                    new CarModel {Name = "Orlando"},
                                     new CarModel {Name = "Rezzo"},
                                      new CarModel {Name = "Silverado"},
                                       new CarModel {Name = "Spark"},
                                        new CarModel {Name = "Tahoe"},
                                       new CarModel {Name = "Tracker"},
                                       new CarModel {Name = "TrailBlazer"},

                    }
                });

                var dbset = context.Set<Manufacture>();

                foreach (var manufacture in manufactureModels)
                {
                    dbset.Add(manufacture);
                }
                context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}

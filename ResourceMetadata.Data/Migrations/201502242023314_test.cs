namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ImagePath = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ManufactureId = c.Int(nullable: false),
                        CarModelId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        FuelType = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .ForeignKey("dbo.Manufactures", t => t.ManufactureId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ManufactureId)
                .Index(t => t.CarModelId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ManufactureId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufactures", t => t.ManufactureId)
                .Index(t => t.ManufactureId);
            
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.IdentityUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LocationId = c.Int(nullable: false),
                        Path = c.String(),
                        Priority = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsShared = c.Boolean(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ResourceActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ResourceId = c.Int(nullable: false),
                        Notes = c.String(),
                        ActivityDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.Resources", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ResourceActivities", "ResourceId", "dbo.Resources");
            DropForeignKey("dbo.Adverts", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "RoleId", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserLogins", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Adverts", "ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.Adverts", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "ManufactureId", "dbo.Manufactures");
            DropIndex("dbo.ResourceActivities", new[] { "ResourceId" });
            DropIndex("dbo.Resources", new[] { "UserId" });
            DropIndex("dbo.Resources", new[] { "LocationId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "UserId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "User_Id" });
            DropIndex("dbo.CarModels", new[] { "ManufactureId" });
            DropIndex("dbo.Adverts", new[] { "UserId" });
            DropIndex("dbo.Adverts", new[] { "CarModelId" });
            DropIndex("dbo.Adverts", new[] { "ManufactureId" });
            DropTable("dbo.ResourceActivities");
            DropTable("dbo.Resources");
            DropTable("dbo.Locations");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.Manufactures");
            DropTable("dbo.CarModels");
            DropTable("dbo.Adverts");
        }
    }
}

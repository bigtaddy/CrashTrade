namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_redundant_models : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResourceActivities", "ResourceId", "dbo.Resources");
            DropForeignKey("dbo.Resources", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Resources", "UserId", "dbo.IdentityUsers");
            DropIndex("dbo.Resources", new[] { "LocationId" });
            DropIndex("dbo.Resources", new[] { "UserId" });
            DropIndex("dbo.ResourceActivities", new[] { "ResourceId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Resources");
            DropTable("dbo.ResourceActivities");
        }
        
        public override void Down()
        {
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
            
            CreateIndex("dbo.ResourceActivities", "ResourceId");
            CreateIndex("dbo.Resources", "UserId");
            CreateIndex("dbo.Resources", "LocationId");
            AddForeignKey("dbo.Resources", "UserId", "dbo.IdentityUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resources", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResourceActivities", "ResourceId", "dbo.Resources", "Id", cascadeDelete: true);
        }
    }
}

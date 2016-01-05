namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createSparePartAdverts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SparePartAdverts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ManufactureId = c.Int(nullable: false),
                        CarModelId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        VIN = c.String(),
                        Contacts = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .ForeignKey("dbo.Manufactures", t => t.ManufactureId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ManufactureId)
                .Index(t => t.CarModelId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.ImageInfoes", "SparePartAdvert_Id", c => c.Int());
            CreateIndex("dbo.ImageInfoes", "SparePartAdvert_Id");
            AddForeignKey("dbo.ImageInfoes", "SparePartAdvert_Id", "dbo.SparePartAdverts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SparePartAdverts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SparePartAdverts", "ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.ImageInfoes", "SparePartAdvert_Id", "dbo.SparePartAdverts");
            DropForeignKey("dbo.SparePartAdverts", "CarModelId", "dbo.CarModels");
            DropIndex("dbo.SparePartAdverts", new[] { "UserId" });
            DropIndex("dbo.SparePartAdverts", new[] { "CarModelId" });
            DropIndex("dbo.SparePartAdverts", new[] { "ManufactureId" });
            DropIndex("dbo.ImageInfoes", new[] { "SparePartAdvert_Id" });
            DropColumn("dbo.ImageInfoes", "SparePartAdvert_Id");
            DropTable("dbo.SparePartAdverts");
        }
    }
}

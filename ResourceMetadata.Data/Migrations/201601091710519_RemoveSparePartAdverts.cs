namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSparePartAdverts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SparePartAdverts", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.ImageInfoes", "SparePartAdvert_Id", "dbo.SparePartAdverts");
            DropForeignKey("dbo.SparePartAdverts", "ManufactureId", "dbo.Manufactures");
            DropForeignKey("dbo.SparePartAdverts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ImageInfoes", new[] { "SparePartAdvert_Id" });
            DropIndex("dbo.SparePartAdverts", new[] { "ManufactureId" });
            DropIndex("dbo.SparePartAdverts", new[] { "CarModelId" });
            DropIndex("dbo.SparePartAdverts", new[] { "UserId" });
            DropColumn("dbo.ImageInfoes", "SparePartAdvert_Id");
            DropTable("dbo.SparePartAdverts");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ImageInfoes", "SparePartAdvert_Id", c => c.Int());
            CreateIndex("dbo.SparePartAdverts", "UserId");
            CreateIndex("dbo.SparePartAdverts", "CarModelId");
            CreateIndex("dbo.SparePartAdverts", "ManufactureId");
            CreateIndex("dbo.ImageInfoes", "SparePartAdvert_Id");
            AddForeignKey("dbo.SparePartAdverts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SparePartAdverts", "ManufactureId", "dbo.Manufactures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImageInfoes", "SparePartAdvert_Id", "dbo.SparePartAdverts", "Id");
            AddForeignKey("dbo.SparePartAdverts", "CarModelId", "dbo.CarModels", "Id", cascadeDelete: true);
        }
    }
}

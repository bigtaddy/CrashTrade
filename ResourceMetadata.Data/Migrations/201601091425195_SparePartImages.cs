namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SparePartImages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageInfoes", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.ImageInfoes", new[] { "AdvertId" });
            RenameColumn(table: "dbo.ImageInfoes", name: "SparePartAdvert_Id", newName: "SparePartAdvertId");
            RenameIndex(table: "dbo.ImageInfoes", name: "IX_SparePartAdvert_Id", newName: "IX_SparePartAdvertId");
            AlterColumn("dbo.ImageInfoes", "AdvertId", c => c.Int());
            CreateIndex("dbo.ImageInfoes", "AdvertId");
            AddForeignKey("dbo.ImageInfoes", "AdvertId", "dbo.Adverts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageInfoes", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.ImageInfoes", new[] { "AdvertId" });
            AlterColumn("dbo.ImageInfoes", "AdvertId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.ImageInfoes", name: "IX_SparePartAdvertId", newName: "IX_SparePartAdvert_Id");
            RenameColumn(table: "dbo.ImageInfoes", name: "SparePartAdvertId", newName: "SparePartAdvert_Id");
            CreateIndex("dbo.ImageInfoes", "AdvertId");
            AddForeignKey("dbo.ImageInfoes", "AdvertId", "dbo.Adverts", "Id", cascadeDelete: true);
        }
    }
}

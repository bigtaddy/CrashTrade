namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageInfo_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        AdvertId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
            DropColumn("dbo.Adverts", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "ImagePath", c => c.String());
            DropForeignKey("dbo.ImageInfoes", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.ImageInfoes", new[] { "AdvertId" });
            DropTable("dbo.ImageInfoes");
        }
    }
}

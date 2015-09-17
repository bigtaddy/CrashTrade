namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewPropertyToAdvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "SweptVolume", c => c.Int(nullable: false));
            AddColumn("dbo.Adverts", "Contacts", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "Contacts");
            DropColumn("dbo.Adverts", "SweptVolume");
        }
    }
}

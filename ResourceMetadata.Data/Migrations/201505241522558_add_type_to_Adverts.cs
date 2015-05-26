namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_type_to_Adverts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "AdvertType", c => c.Int(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "AdvertType");
        }
    }
}

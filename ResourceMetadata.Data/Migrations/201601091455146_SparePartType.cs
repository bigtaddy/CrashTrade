namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SparePartType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "SparePartType", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "SparePartType");
        }
    }
}

namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typesChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "SaleType", c => c.Boolean(nullable: false));
            DropColumn("dbo.Adverts", "SparePartType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "SparePartType", c => c.Boolean(nullable: false));
            DropColumn("dbo.Adverts", "SaleType");
        }
    }
}

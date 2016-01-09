namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVinToAdverts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "VIN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "VIN");
        }
    }
}

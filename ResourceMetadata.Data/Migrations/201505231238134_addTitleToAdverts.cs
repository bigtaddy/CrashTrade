namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTitleToAdverts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "Title");
        }
    }
}

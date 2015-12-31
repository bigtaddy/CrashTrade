namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTransmissionToAdverts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "TransmissionType", c => c.Int(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adverts", "TransmissionType");
        }
    }
}

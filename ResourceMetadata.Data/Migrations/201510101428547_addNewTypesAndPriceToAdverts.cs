namespace ResourceMetadata.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewTypesAndPriceToAdverts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "CoachworkRepairType", c => c.Boolean(nullable: false));
            AddColumn("dbo.Adverts", "MechanicalRepairType", c => c.Boolean(nullable: false));
            AddColumn("dbo.Adverts", "SparePartType", c => c.Boolean(nullable: false));
            AddColumn("dbo.Adverts", "Price", c => c.Int());
            AlterColumn("dbo.Adverts", "SweptVolume", c => c.Int());
            DropColumn("dbo.Adverts", "AdvertType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "AdvertType", c => c.Int(nullable: false));
            AlterColumn("dbo.Adverts", "SweptVolume", c => c.Int(nullable: false));
            DropColumn("dbo.Adverts", "Price");
            DropColumn("dbo.Adverts", "SparePartType");
            DropColumn("dbo.Adverts", "MechanicalRepairType");
            DropColumn("dbo.Adverts", "CoachworkRepairType");
        }
    }
}

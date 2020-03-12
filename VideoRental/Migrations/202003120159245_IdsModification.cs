namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdsModification : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.MembershipTypes");
            DropPrimaryKey("dbo.Movies");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.MembershipTypes", "Id");
            DropColumn("dbo.Movies", "Id");
            AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.MembershipTypes", "MemberShipTypeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Movies", "MovieId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "CustomerId");
            AddPrimaryKey("dbo.MembershipTypes", "MemberShipTypeId");
            AddPrimaryKey("dbo.Movies", "MovieId");            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.MembershipTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.MembershipTypes");
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Movies", "MovieId");
            DropColumn("dbo.MembershipTypes", "MemberShipTypeId");
            DropColumn("dbo.Customers", "CustomerId");
            AddPrimaryKey("dbo.Movies", "Id");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
        }
    }
}

namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelModifications : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.MembershipTypes");
            DropColumn("dbo.Customers", "CustomerId");
            DropColumn("dbo.MembershipTypes", "MemberShipTypeId");
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Byte());
            AddColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DiscountRate", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "MemberShipTypeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            DropPrimaryKey("dbo.MembershipTypes");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.MembershipTypes", "DiscountRate", c => c.Int(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Int(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "Id");
            DropColumn("dbo.Customers", "MembershipType_Id");
            DropColumn("dbo.Customers", "MemberShipTypeId");
            DropColumn("dbo.Customers", "Id");
            AddPrimaryKey("dbo.MembershipTypes", "MemberShipTypeId");
            AddPrimaryKey("dbo.Customers", "CustomerId");
        }
    }
}

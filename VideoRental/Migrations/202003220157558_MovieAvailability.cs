namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MoviesAvailables", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MoviesAvailables");
        }
    }
}

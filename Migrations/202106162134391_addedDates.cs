namespace Rvas_ispit_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentalBooks", "dateRented", c => c.DateTime(nullable: false));
            AddColumn("dbo.RentalBooks", "dateReturned", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentalBooks", "dateReturned");
            DropColumn("dbo.RentalBooks", "dateRented");
        }
    }
}

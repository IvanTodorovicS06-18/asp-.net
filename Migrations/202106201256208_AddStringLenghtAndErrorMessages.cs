namespace Rvas_ispit_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringLenghtAndErrorMessages : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "author", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "genre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 18));
            AlterColumn("dbo.Books", "language", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "lastname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "adress", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "adress", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "phone", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "lastname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "language", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "genre", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "author", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "title", c => c.String(nullable: false));
        }
    }
}

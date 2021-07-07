namespace Rvas_ispit_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatePublishers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Publishers(publisherName,phone) VALUES('Vulkan','011 111 2222')");
            Sql("INSERT INTO Publishers(publisherName,phone) VALUES('Laguna','011 555 7777')");
            Sql("INSERT INTO Publishers(publisherName,phone) VALUES('Carobna knjiga','011 323 2244')");
            Sql("INSERT INTO Publishers(publisherName,phone) VALUES('The English book','011 888 2255')");
            Sql("INSERT INTO Publishers(publisherName,phone) VALUES('TOR fantasy','011 777 2266')");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.Publishers");
        }
    }
}

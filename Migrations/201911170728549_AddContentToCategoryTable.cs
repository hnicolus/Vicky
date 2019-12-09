namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContentToCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES('Movies')");
            Sql("INSERT INTO Categories (Name) VALUES('Series')");
            Sql("INSERT INTO Categories (Name) VALUES('Documentary')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories (Name) VALUES('Movies')");
            Sql("DELETE FROM Categories (Name) VALUES('Series')");
            Sql("DELETE FROM Categories (Name) VALUES('Documentary')");
        }
    }
}

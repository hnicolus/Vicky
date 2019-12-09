namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Categories (Name) VALUES('Action')");
            Sql("INSERT INTO Categories (Name) VALUES('Animation')");
            Sql("INSERT INTO Categories (Name) VALUES('Thriller')");
            Sql("INSERT INTO Categories (Name) VALUES('Horror')");
            Sql("INSERT INTO Categories (Name) VALUES('Sci-Fi')");
            Sql("INSERT INTO Categories (Name) VALUES('Comedy')");
            Sql("INSERT INTO Categories (Name) VALUES('History')");
            Sql("INSERT INTO Categories (Name) VALUES('Documentary')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}

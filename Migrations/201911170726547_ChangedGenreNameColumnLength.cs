namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedGenreNameColumnLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 200));
            Sql("INSERT INTO Genres (Name) VALUES('Action')");
            Sql("INSERT INTO Genres (Name) VALUES('Animation')");
            Sql("INSERT INTO Genres (Name) VALUES('Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES('Horror')");
            Sql("INSERT INTO Genres (Name) VALUES('Sci-Fi')");
            Sql("INSERT INTO Genres (Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES('History')");
            Sql("INSERT INTO Genres (Name) VALUES('Documentary')");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}

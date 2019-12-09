namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseDateColumnToSeasonTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seasons", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seasons", "ReleaseDate");
        }
    }
}

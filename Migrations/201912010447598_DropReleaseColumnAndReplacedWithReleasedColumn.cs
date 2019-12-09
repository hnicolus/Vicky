namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropReleaseColumnAndReplacedWithReleasedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "PublishedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Series", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Seasons", "Description", c => c.String());
            AddColumn("dbo.Seasons", "PublishedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Seasons", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Seasons", "Views", c => c.Int());
            AddColumn("dbo.Episodes", "PublishedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Episodes", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Episodes", "Views", c => c.Int());
            AddColumn("dbo.Tags", "Episode_Id", c => c.Int());
            AddColumn("dbo.Tags", "Season_Id", c => c.Int());
            AlterColumn("dbo.Series", "Name", c => c.String());
            CreateIndex("dbo.Tags", "Episode_Id");
            CreateIndex("dbo.Tags", "Season_Id");
            AddForeignKey("dbo.Tags", "Episode_Id", "dbo.Episodes", "Id");
            AddForeignKey("dbo.Tags", "Season_Id", "dbo.Seasons", "Id");
            DropColumn("dbo.Seasons", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seasons", "ReleaseDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Tags", "Season_Id", "dbo.Seasons");
            DropForeignKey("dbo.Tags", "Episode_Id", "dbo.Episodes");
            DropIndex("dbo.Tags", new[] { "Season_Id" });
            DropIndex("dbo.Tags", new[] { "Episode_Id" });
            AlterColumn("dbo.Series", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Tags", "Season_Id");
            DropColumn("dbo.Tags", "Episode_Id");
            DropColumn("dbo.Episodes", "Views");
            DropColumn("dbo.Episodes", "ReleasedDate");
            DropColumn("dbo.Episodes", "PublishedDate");
            DropColumn("dbo.Seasons", "Views");
            DropColumn("dbo.Seasons", "ReleasedDate");
            DropColumn("dbo.Seasons", "PublishedDate");
            DropColumn("dbo.Seasons", "Description");
            DropColumn("dbo.Series", "ReleasedDate");
            DropColumn("dbo.Series", "PublishedDate");
        }
    }
}

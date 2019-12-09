namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSeriesTagesCategoriesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Series", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.Series", new[] { "Tag_Id" });
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .Index(t => t.Series_Id);
            
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Season_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.Season_Id)
                .Index(t => t.Season_Id);
            
            CreateTable(
                "dbo.TagSeries",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Series_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Series_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Series_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Series_Id);
            
            AddColumn("dbo.Series", "Description", c => c.String());
            AddColumn("dbo.Series", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Series", "Views", c => c.Int());
            CreateIndex("dbo.Series", "CategoryId");
            CreateIndex("dbo.Series", "GenreId");
            AddForeignKey("dbo.Series", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Series", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Series", "Tag_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Tag_Id", c => c.Int());
            DropForeignKey("dbo.TagSeries", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.TagSeries", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Seasons", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.Episodes", "Season_Id", "dbo.Seasons");
            DropForeignKey("dbo.Series", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Series", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TagSeries", new[] { "Series_Id" });
            DropIndex("dbo.TagSeries", new[] { "Tag_Id" });
            DropIndex("dbo.Episodes", new[] { "Season_Id" });
            DropIndex("dbo.Seasons", new[] { "Series_Id" });
            DropIndex("dbo.Series", new[] { "GenreId" });
            DropIndex("dbo.Series", new[] { "CategoryId" });
            DropColumn("dbo.Series", "Views");
            DropColumn("dbo.Series", "GenreId");
            DropColumn("dbo.Series", "CategoryId");
            DropColumn("dbo.Series", "Description");
            DropTable("dbo.TagSeries");
            DropTable("dbo.Episodes");
            DropTable("dbo.Seasons");
            CreateIndex("dbo.Series", "Tag_Id");
            AddForeignKey("dbo.Series", "Tag_Id", "dbo.Tags", "Id");
        }
    }
}

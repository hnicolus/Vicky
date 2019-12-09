namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGenreTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Tags", new[] { "Movie_Id" });
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Tag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.Tag_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.MovieTags",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Tag_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Tag_Id);
            
            DropColumn("dbo.Tags", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Movie_Id", c => c.Int());
            DropForeignKey("dbo.MovieTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.MovieTags", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Series", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.MovieTags", new[] { "Tag_Id" });
            DropIndex("dbo.MovieTags", new[] { "Movie_Id" });
            DropIndex("dbo.Series", new[] { "Tag_Id" });
            DropTable("dbo.MovieTags");
            DropTable("dbo.Series");
            CreateIndex("dbo.Tags", "Movie_Id");
            AddForeignKey("dbo.Tags", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}

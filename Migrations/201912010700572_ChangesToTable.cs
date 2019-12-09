namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seasons", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Episodes", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seasons", "GenreId");
            CreateIndex("dbo.Episodes", "GenreId");
            AddForeignKey("dbo.Episodes", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Seasons", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seasons", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Episodes", "GenreId", "dbo.Genres");
            DropIndex("dbo.Episodes", new[] { "GenreId" });
            DropIndex("dbo.Seasons", new[] { "GenreId" });
            DropColumn("dbo.Episodes", "GenreId");
            DropColumn("dbo.Seasons", "GenreId");
        }
    }
}

namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColumnToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Category_Id");
            AddForeignKey("dbo.Movies", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Movies", new[] { "Category_Id" });
            DropColumn("dbo.Movies", "Category_Id");
        }
    }
}

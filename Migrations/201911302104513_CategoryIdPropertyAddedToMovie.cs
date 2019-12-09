namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIdPropertyAddedToMovie : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Movies", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Movies", name: "CategoryId", newName: "Category_Id");
        }
    }
}

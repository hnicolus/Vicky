namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewColumnToMoviesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Views", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Views");
        }
    }
}

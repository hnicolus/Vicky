namespace Vicky.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequirementForNameColumnInAllTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seasons", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Seasons", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Episodes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Episodes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Episodes", "Description", c => c.String());
            AlterColumn("dbo.Episodes", "Name", c => c.String());
            AlterColumn("dbo.Seasons", "Description", c => c.String());
            AlterColumn("dbo.Seasons", "Name", c => c.String());
        }
    }
}

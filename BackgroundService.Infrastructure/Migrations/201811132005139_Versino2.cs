namespace BackgroundService.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versino2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SeriesEntries", "Date", c => c.String());
            AlterColumn("dbo.Series", "Start", c => c.String());
            AlterColumn("dbo.Series", "End", c => c.String());
            AlterColumn("dbo.Series", "Updated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Series", "Updated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Series", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Series", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SeriesEntries", "Date", c => c.DateTime(nullable: false));
        }
    }
}

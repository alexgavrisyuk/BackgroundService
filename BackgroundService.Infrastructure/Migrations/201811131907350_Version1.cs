namespace BackgroundService.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeriesEntries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeriesId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .Index(t => t.SeriesId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Units = c.String(),
                        F = c.String(),
                        UnitsShort = c.String(),
                        Description = c.String(),
                        Copyright = c.String(),
                        Source = c.String(),
                        Iso366 = c.String(),
                        Geography = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeriesEntries", "SeriesId", "dbo.Series");
            DropIndex("dbo.SeriesEntries", new[] { "SeriesId" });
            DropTable("dbo.Series");
            DropTable("dbo.SeriesEntries");
        }
    }
}

namespace GetBuckets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Team", "LocationID", "dbo.Location");
            DropIndex("dbo.Team", new[] { "LocationID" });
            AlterColumn("dbo.Team", "LocationID", c => c.Int());
            CreateIndex("dbo.Team", "LocationID");
            AddForeignKey("dbo.Team", "LocationID", "dbo.Location", "LocationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team", "LocationID", "dbo.Location");
            DropIndex("dbo.Team", new[] { "LocationID" });
            AlterColumn("dbo.Team", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Team", "LocationID");
            AddForeignKey("dbo.Team", "LocationID", "dbo.Location", "LocationID", cascadeDelete: true);
        }
    }
}

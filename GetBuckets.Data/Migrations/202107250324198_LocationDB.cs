namespace GetBuckets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Location", "LocationName", c => c.String(nullable: false));
            AlterColumn("dbo.Location", "Street", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Location", "Street", c => c.String());
            AlterColumn("dbo.Location", "LocationName", c => c.String());
        }
    }
}

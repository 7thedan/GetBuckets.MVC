namespace GetBuckets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Review", "LocationName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "LocationName", c => c.String(nullable: false));
        }
    }
}

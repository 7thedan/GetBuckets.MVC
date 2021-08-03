namespace GetBuckets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guidinlocatiodb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location", "OwnerID");
        }
    }
}

namespace GetBuckets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeamDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "OwnerID");
        }
    }
}

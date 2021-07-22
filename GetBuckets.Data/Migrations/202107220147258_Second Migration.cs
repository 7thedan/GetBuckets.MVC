namespace GetBuckets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Player", "TeamID", "dbo.Team");
            DropIndex("dbo.Player", new[] { "TeamID" });
            AlterColumn("dbo.Player", "TeamID", c => c.Int());
            CreateIndex("dbo.Player", "TeamID");
            AddForeignKey("dbo.Player", "TeamID", "dbo.Team", "TeamID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "TeamID", "dbo.Team");
            DropIndex("dbo.Player", new[] { "TeamID" });
            AlterColumn("dbo.Player", "TeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Player", "TeamID");
            AddForeignKey("dbo.Player", "TeamID", "dbo.Team", "TeamID", cascadeDelete: true);
        }
    }
}

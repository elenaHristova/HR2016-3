namespace ProjectHack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoalsId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goal", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goal", "UserId");
        }
    }
}

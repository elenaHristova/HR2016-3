namespace ProjectHack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TimePeriodInDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        GoalId = c.Int(nullable: false, identity: true),
                        GoalTitle = c.String(),
                    })
                .PrimaryKey(t => t.GoalId);
            
            CreateTable(
                "dbo.PersonalInfo",
                c => new
                    {
                        PersonalInfoId = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonalInfoId);
            
            CreateTable(
                "dbo.TimePeriod",
                c => new
                    {
                        TimePeriodId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TitleId = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimePeriodId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Categories = c.String(),
                        Activities = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.TimePeriod");
            DropTable("dbo.PersonalInfo");
            DropTable("dbo.Goal");
            DropTable("dbo.Category");
        }
    }
}

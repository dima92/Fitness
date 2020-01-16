namespace Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CaloriesPerMinute = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenderId = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Eatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Moment = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Food_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id)
                .Index(t => t.UserId)
                .Index(t => t.Food_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Proteins = c.Double(nullable: false),
                        Fats = c.Double(nullable: false),
                        Carbohydrates = c.Double(nullable: false),
                        Calories = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Exercises", "UserId", "dbo.Users");
            DropForeignKey("dbo.Eatings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Exercises", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            DropIndex("dbo.Eatings", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Exercises", new[] { "UserId" });
            DropIndex("dbo.Exercises", new[] { "ActivityId" });
            DropTable("dbo.Foods");
            DropTable("dbo.Genders");
            DropTable("dbo.Eatings");
            DropTable("dbo.Users");
            DropTable("dbo.Exercises");
            DropTable("dbo.Activities");
        }
    }
}

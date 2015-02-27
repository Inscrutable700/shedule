namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schoolboys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolboyLessons",
                c => new
                    {
                        Schoolboy_Id = c.Int(nullable: false),
                        Lesson_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Schoolboy_Id, t.Lesson_Id })
                .ForeignKey("dbo.Schoolboys", t => t.Schoolboy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.Lesson_Id, cascadeDelete: true)
                .Index(t => t.Schoolboy_Id)
                .Index(t => t.Lesson_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolboyLessons", "Lesson_Id", "dbo.Lessons");
            DropForeignKey("dbo.SchoolboyLessons", "Schoolboy_Id", "dbo.Schoolboys");
            DropIndex("dbo.SchoolboyLessons", new[] { "Lesson_Id" });
            DropIndex("dbo.SchoolboyLessons", new[] { "Schoolboy_Id" });
            DropTable("dbo.SchoolboyLessons");
            DropTable("dbo.Schoolboys");
            DropTable("dbo.Lessons");
        }
    }
}

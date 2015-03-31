namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LasName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "TeachingID", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "Begin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lessons", "PeriodNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "TeacherID", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "Count", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "TeachingID");
            CreateIndex("dbo.Lessons", "TeacherID");
            AddForeignKey("dbo.Lessons", "TeacherID", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessons", "TeachingID", "dbo.Teachings", "Id", cascadeDelete: true);
            DropColumn("dbo.Lessons", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Name", c => c.String());
            DropForeignKey("dbo.Lessons", "TeachingID", "dbo.Teachings");
            DropForeignKey("dbo.Lessons", "TeacherID", "dbo.Teachers");
            DropIndex("dbo.Lessons", new[] { "TeacherID" });
            DropIndex("dbo.Lessons", new[] { "TeachingID" });
            DropColumn("dbo.Lessons", "Count");
            DropColumn("dbo.Lessons", "TeacherID");
            DropColumn("dbo.Lessons", "PeriodNumber");
            DropColumn("dbo.Lessons", "Begin");
            DropColumn("dbo.Lessons", "TeachingID");
            DropTable("dbo.Teachings");
            DropTable("dbo.Teachers");
            DropTable("dbo.Classrooms");
        }
    }
}

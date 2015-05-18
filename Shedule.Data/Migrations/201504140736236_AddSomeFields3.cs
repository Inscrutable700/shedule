namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeFields3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "ClassroomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "ClassroomId");
            AddForeignKey("dbo.Lessons", "ClassroomId", "dbo.Classrooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Lessons", new[] { "ClassroomId" });
            DropColumn("dbo.Lessons", "ClassroomId");
        }
    }
}

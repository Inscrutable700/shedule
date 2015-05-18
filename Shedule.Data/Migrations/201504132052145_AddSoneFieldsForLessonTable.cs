namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoneFieldsForLessonTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "DayNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "DayNumber");
        }
    }
}

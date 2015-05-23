namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeFieldsForTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "MiddleName", c => c.String());
            AddColumn("dbo.Teachers", "Description", c => c.String());
            AddColumn("dbo.Teachers", "Degree", c => c.String());
            AddColumn("dbo.Teachers", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Birthday");
            DropColumn("dbo.Teachers", "Degree");
            DropColumn("dbo.Teachers", "Description");
            DropColumn("dbo.Teachers", "MiddleName");
        }
    }
}

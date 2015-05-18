namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeFields2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lessons", "Begin");
            DropColumn("dbo.Lessons", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Lessons", "Begin", c => c.DateTime(nullable: false));
        }
    }
}

namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoNotNowWhatAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classrooms", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Classrooms", "BuildingName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classrooms", "BuildingName");
            DropColumn("dbo.Classrooms", "Capacity");
        }
    }
}

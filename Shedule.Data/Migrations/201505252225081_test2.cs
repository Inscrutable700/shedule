namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SchoolboyToTariffs");
            AddPrimaryKey("dbo.SchoolboyToTariffs", new[] { "SchoolboyId", "LessonId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SchoolboyToTariffs");
            AddPrimaryKey("dbo.SchoolboyToTariffs", new[] { "SchoolboyId", "TariffId" });
        }
    }
}

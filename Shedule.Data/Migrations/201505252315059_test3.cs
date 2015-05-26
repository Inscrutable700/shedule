namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schoolboys", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schoolboys", "Adress", c => c.String());
            AddColumn("dbo.Schoolboys", "PhoneNumber", c => c.String());
            AddColumn("dbo.Schoolboys", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schoolboys", "Email");
            DropColumn("dbo.Schoolboys", "PhoneNumber");
            DropColumn("dbo.Schoolboys", "Adress");
            DropColumn("dbo.Schoolboys", "Birthday");
        }
    }
}

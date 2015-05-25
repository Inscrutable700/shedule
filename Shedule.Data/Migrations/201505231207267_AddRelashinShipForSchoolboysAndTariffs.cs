namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelashinShipForSchoolboysAndTariffs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TariffSchoolboys",
                c => new
                    {
                        Tariff_Id = c.Int(nullable: false),
                        Schoolboy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tariff_Id, t.Schoolboy_Id })
                .ForeignKey("dbo.Tariffs", t => t.Tariff_Id, cascadeDelete: false)
                .ForeignKey("dbo.Schoolboys", t => t.Schoolboy_Id, cascadeDelete: false )
                .Index(t => t.Tariff_Id)
                .Index(t => t.Schoolboy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TariffSchoolboys", "Schoolboy_Id", "dbo.Schoolboys");
            DropForeignKey("dbo.TariffSchoolboys", "Tariff_Id", "dbo.Tariffs");
            DropIndex("dbo.TariffSchoolboys", new[] { "Schoolboy_Id" });
            DropIndex("dbo.TariffSchoolboys", new[] { "Tariff_Id" });
            DropTable("dbo.TariffSchoolboys");
        }
    }
}

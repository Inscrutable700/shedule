namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchoolboyLessons", "Schoolboy_Id", "dbo.Schoolboys");
            DropForeignKey("dbo.SchoolboyLessons", "Lesson_Id", "dbo.Lessons");
            DropForeignKey("dbo.TariffSchoolboys", "Tariff_Id", "dbo.Tariffs");
            DropForeignKey("dbo.TariffSchoolboys", "Schoolboy_Id", "dbo.Schoolboys");
            DropIndex("dbo.SchoolboyLessons", new[] { "Schoolboy_Id" });
            DropIndex("dbo.SchoolboyLessons", new[] { "Lesson_Id" });
            DropIndex("dbo.TariffSchoolboys", new[] { "Tariff_Id" });
            DropIndex("dbo.TariffSchoolboys", new[] { "Schoolboy_Id" });
            CreateTable(
                "dbo.SchoolboyToTariffs",
                c => new
                    {
                        SchoolboyId = c.Int(nullable: false),
                        TariffId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SchoolboyId, t.TariffId })
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: false)
                .ForeignKey("dbo.Schoolboys", t => t.SchoolboyId, cascadeDelete: false)
                .ForeignKey("dbo.Tariffs", t => t.TariffId, cascadeDelete: false)
                .Index(t => t.SchoolboyId)
                .Index(t => t.TariffId)
                .Index(t => t.LessonId);
            
            DropTable("dbo.SchoolboyLessons");
            DropTable("dbo.TariffSchoolboys");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TariffSchoolboys",
                c => new
                    {
                        Tariff_Id = c.Int(nullable: false),
                        Schoolboy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tariff_Id, t.Schoolboy_Id });
            
            CreateTable(
                "dbo.SchoolboyLessons",
                c => new
                    {
                        Schoolboy_Id = c.Int(nullable: false),
                        Lesson_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Schoolboy_Id, t.Lesson_Id });
            
            DropForeignKey("dbo.SchoolboyToTariffs", "TariffId", "dbo.Tariffs");
            DropForeignKey("dbo.SchoolboyToTariffs", "SchoolboyId", "dbo.Schoolboys");
            DropForeignKey("dbo.SchoolboyToTariffs", "LessonId", "dbo.Lessons");
            DropIndex("dbo.SchoolboyToTariffs", new[] { "LessonId" });
            DropIndex("dbo.SchoolboyToTariffs", new[] { "TariffId" });
            DropIndex("dbo.SchoolboyToTariffs", new[] { "SchoolboyId" });
            DropTable("dbo.SchoolboyToTariffs");
            CreateIndex("dbo.TariffSchoolboys", "Schoolboy_Id");
            CreateIndex("dbo.TariffSchoolboys", "Tariff_Id");
            CreateIndex("dbo.SchoolboyLessons", "Lesson_Id");
            CreateIndex("dbo.SchoolboyLessons", "Schoolboy_Id");
            AddForeignKey("dbo.TariffSchoolboys", "Schoolboy_Id", "dbo.Schoolboys", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TariffSchoolboys", "Tariff_Id", "dbo.Tariffs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SchoolboyLessons", "Lesson_Id", "dbo.Lessons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SchoolboyLessons", "Schoolboy_Id", "dbo.Schoolboys", "Id", cascadeDelete: true);
        }
    }
}

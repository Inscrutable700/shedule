namespace Shedule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtariffsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tariffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TeachingId = c.Int(nullable: false),
                        CountOfPairs = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachings", t => t.TeachingId, cascadeDelete: false)
                .Index(t => t.TeachingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tariffs", "TeachingId", "dbo.Teachings");
            DropIndex("dbo.Tariffs", new[] { "TeachingId" });
            DropTable("dbo.Tariffs");
        }
    }
}

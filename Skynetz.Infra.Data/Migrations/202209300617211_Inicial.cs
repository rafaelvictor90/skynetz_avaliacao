namespace Skynetz.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlatRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Origin = c.String(),
                        Destiny = c.String(),
                        MinuteValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanFaleMais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinuteTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanFaleMais");
            DropTable("dbo.FlatRates");
        }
    }
}

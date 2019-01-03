namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coefficients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Coefficients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        Wentylator_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("public.Wentylators", t => t.Wentylator_ID)
                .Index(t => t.Wentylator_ID);
            
            AddColumn("public.Wentylators", "AirMassFlowFrom", c => c.Double(nullable: false));
            AddColumn("public.Wentylators", "AirMAssFlowTo", c => c.Double(nullable: false));
            DropColumn("public.Wentylators", "Pressure");
        }
        
        public override void Down()
        {
            AddColumn("public.Wentylators", "Pressure", c => c.Double(nullable: false));
            DropForeignKey("public.Coefficients", "Wentylator_ID", "public.Wentylators");
            DropIndex("public.Coefficients", new[] { "Wentylator_ID" });
            DropColumn("public.Wentylators", "AirMAssFlowTo");
            DropColumn("public.Wentylators", "AirMassFlowFrom");
            DropTable("public.Coefficients");
        }
    }
}

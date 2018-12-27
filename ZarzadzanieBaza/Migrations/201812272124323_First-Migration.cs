namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Natures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("public.Wentylators", "NatureId", c => c.Int(nullable: false));
            AlterColumn("public.Wentylators", "Revolution", c => c.Double(nullable: false));
            CreateIndex("public.Wentylators", "NatureId");
            AddForeignKey("public.Wentylators", "NatureId", "public.Natures", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.Wentylators", "NatureId", "public.Natures");
            DropIndex("public.Wentylators", new[] { "NatureId" });
            AlterColumn("public.Wentylators", "Revolution", c => c.Int(nullable: false));
            DropColumn("public.Wentylators", "NatureId");
            DropTable("public.Natures");
        }
    }
}

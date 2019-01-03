namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NatureId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Wentylators", "Nature_ID", "public.Natures");
            DropIndex("public.Wentylators", new[] { "Nature_ID" });
            RenameColumn(table: "public.Wentylators", name: "Nature_ID", newName: "NatureId");
            AlterColumn("public.Wentylators", "NatureId", c => c.Int(nullable: false));
            CreateIndex("public.Wentylators", "NatureId");
            AddForeignKey("public.Wentylators", "NatureId", "public.Natures", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("public.Wentylators", "NatureId", "public.Natures");
            DropIndex("public.Wentylators", new[] { "NatureId" });
            AlterColumn("public.Wentylators", "NatureId", c => c.Int());
            RenameColumn(table: "public.Wentylators", name: "NatureId", newName: "Nature_ID");
            CreateIndex("public.Wentylators", "Nature_ID");
            AddForeignKey("public.Wentylators", "Nature_ID", "public.Natures", "ID");
        }
    }
}

namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lazyloading : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Wentylators", "NatureId", "public.Natures");
            DropIndex("public.Wentylators", new[] { "NatureId" });
            RenameColumn(table: "public.Wentylators", name: "NatureId", newName: "Nature_ID");
            AlterColumn("public.Wentylators", "Nature_ID", c => c.Int());
            CreateIndex("public.Wentylators", "Nature_ID");
            AddForeignKey("public.Wentylators", "Nature_ID", "public.Natures", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("public.Wentylators", "Nature_ID", "public.Natures");
            DropIndex("public.Wentylators", new[] { "Nature_ID" });
            AlterColumn("public.Wentylators", "Nature_ID", c => c.Int(nullable: false));
            RenameColumn(table: "public.Wentylators", name: "Nature_ID", newName: "NatureId");
            CreateIndex("public.Wentylators", "NatureId");
            AddForeignKey("public.Wentylators", "NatureId", "public.Natures", "ID", cascadeDelete: true);
        }
    }
}

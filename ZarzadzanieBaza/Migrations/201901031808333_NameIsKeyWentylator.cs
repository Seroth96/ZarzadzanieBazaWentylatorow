namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameIsKeyWentylator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Coefficients", "Wentylator_ID", "public.Wentylators");
            DropIndex("public.Coefficients", new[] { "Wentylator_ID" });
            DropIndex("public.Wentylators", new[] { "Name" });
            RenameColumn(table: "public.Coefficients", name: "Wentylator_ID", newName: "Wentylator_Name");
            DropPrimaryKey("public.Wentylators");
            AlterColumn("public.Coefficients", "Wentylator_Name", c => c.String(maxLength: 128));
            AlterColumn("public.Wentylators", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("public.Wentylators", "Name");
            CreateIndex("public.Coefficients", "Wentylator_Name");
            CreateIndex("public.Wentylators", "Name", unique: true);
            AddForeignKey("public.Coefficients", "Wentylator_Name", "public.Wentylators", "Name");
            DropColumn("public.Wentylators", "ID");
        }
        
        public override void Down()
        {
            AddColumn("public.Wentylators", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("public.Coefficients", "Wentylator_Name", "public.Wentylators");
            DropIndex("public.Wentylators", new[] { "Name" });
            DropIndex("public.Coefficients", new[] { "Wentylator_Name" });
            DropPrimaryKey("public.Wentylators");
            AlterColumn("public.Wentylators", "Name", c => c.String());
            AlterColumn("public.Coefficients", "Wentylator_Name", c => c.Int());
            AddPrimaryKey("public.Wentylators", "ID");
            RenameColumn(table: "public.Coefficients", name: "Wentylator_Name", newName: "Wentylator_ID");
            CreateIndex("public.Wentylators", "Name", unique: true);
            CreateIndex("public.Coefficients", "Wentylator_ID");
            AddForeignKey("public.Coefficients", "Wentylator_ID", "public.Wentylators", "ID");
        }
    }
}

namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Coefficients", "Wentylator_Name", "public.Wentylators");
            DropIndex("public.Coefficients", new[] { "Wentylator_Name" });
            DropIndex("public.Wentylators", new[] { "Name" });
            RenameColumn(table: "public.Coefficients", name: "Wentylator_Name", newName: "Wentylator_ID");
            DropPrimaryKey("public.Wentylators");
            AddColumn("public.Wentylators", "ID", c => c.Int(nullable: false, identity: true));
            //AlterColumn("public.Coefficients", "Wentylator_ID", c => c.Int();
            Sql("ALTER TABLE \"Coefficients\" ALTER COLUMN \"Wentylator_ID\" TYPE integer USING (\"Wentylator_ID\"::integer)");
            AlterColumn("public.Wentylators", "Name", c => c.String());
            AddPrimaryKey("public.Wentylators", "ID");
            CreateIndex("public.Coefficients", "Wentylator_ID");
            CreateIndex("public.Wentylators", "Name", unique: true);
            AddForeignKey("public.Coefficients", "Wentylator_ID", "public.Wentylators", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("public.Coefficients", "Wentylator_ID", "public.Wentylators");
            DropIndex("public.Wentylators", new[] { "Name" });
            DropIndex("public.Coefficients", new[] { "Wentylator_ID" });
            DropPrimaryKey("public.Wentylators");
            AlterColumn("public.Wentylators", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("public.Coefficients", "Wentylator_ID", c => c.String(maxLength: 128));
            DropColumn("public.Wentylators", "ID");
            AddPrimaryKey("public.Wentylators", "Name");
            RenameColumn(table: "public.Coefficients", name: "Wentylator_ID", newName: "Wentylator_Name");
            CreateIndex("public.Wentylators", "Name", unique: true);
            CreateIndex("public.Coefficients", "Wentylator_Name");
            AddForeignKey("public.Coefficients", "Wentylator_Name", "public.Wentylators", "Name");
        }
    }
}

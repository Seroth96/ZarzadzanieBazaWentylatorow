namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("public.Wentylators", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("public.Wentylators", new[] { "Name" });
        }
    }
}

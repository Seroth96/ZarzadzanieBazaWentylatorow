namespace ZarzadzanieBaza.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZarzadzanieBaza.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<ZarzadzanieBaza.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ZarzadzanieBaza.DBContext";
        }

        protected override void Seed(ZarzadzanieBaza.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Natures.AddOrUpdate(
              p => p.Name,
              new Nature { Name = "Promieniowe" },
              new Nature { Name = "Przeciwwybuchowe" },
              new Nature { Name = "Dachowe" },
              new Nature { Name = "Z tworzyw sztucznych" },
              new Nature { Name = "Specjalne" },
              new Nature { Name = "Transportowe" },
              new Nature { Name = "Do zabudowy" }
            );
            //
        }
    }
}

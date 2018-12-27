
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarzadzanieBaza.Model;

namespace ZarzadzanieBaza
{
    public class DBContext : DbContext
    {
        public DbSet<Wentylator> Wentylatory { get; set; }
        public DbSet<Nature> Natures { get; set; }

        public DBContext() : base(nameOrConnectionString: "BazaWentylatorow") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}

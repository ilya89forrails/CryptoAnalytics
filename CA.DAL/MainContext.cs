using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.DAL
{
    public class MainContext : DbContext
    {
        public MainContext() :base("DbConnection") { }

        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<WeeklyAverage> WeeklyAverages { get; set; }
        public DbSet<Total> Totals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MainContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

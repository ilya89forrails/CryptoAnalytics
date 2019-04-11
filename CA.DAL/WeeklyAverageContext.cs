using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.DAL
{
   public class WeeklyAverageContext : DbContext
    {
        public WeeklyAverageContext()
            :base("DbConnection")
        { }

        public DbSet<WeeklyAverage> WeeklyAverages { get; set; }
    }
}

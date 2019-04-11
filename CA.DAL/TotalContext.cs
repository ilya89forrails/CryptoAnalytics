using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.DAL
{
    class TotalContext : DbContext
    {
        public TotalContext()
            :base("DbConnection")
        { }

        public DbSet<Total> Totals { get; set; }
    }
}

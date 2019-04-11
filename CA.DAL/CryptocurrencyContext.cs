using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.DAL
{
    public class CryptocurrencyContext : DbContext
    {
        public CryptocurrencyContext()
            :base("DbConnection")
        { }

        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
    }
}

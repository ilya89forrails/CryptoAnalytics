using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.DAL;

namespace CA.BL
{
    class WeeklyAverageCreator
    {
        WeeklyAverageContext dbAvg = new WeeklyAverageContext();
        CryptocurrencyContext dbCrypto = new CryptocurrencyContext();

        private void WeeklyAvgerages()
        {

            var cryptos = from crypto in dbCrypto.Cryptocurrencies
                          where crypto.TimeStamp >= DateTime.Now.AddDays(-5)
                          select crypto.Name;


            //var cryptos = dbCrypto.Cryptocurrencies.Where(p => p.TimeStamp >= DateTime.Now.AddDays(-5));
        }


        public void CreateWeeklyAverage()
        {

        }

    }
}

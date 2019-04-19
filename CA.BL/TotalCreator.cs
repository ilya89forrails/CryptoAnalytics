using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.DAL;
using System.Data.Entity.SqlServer;

namespace CA.BL
{
    class TotalCreator
    {
        public void CreateTotal()
        {
            MainContext dbCrypto = new MainContext();
            List<WeeklyAverage> avgs = (from u in dbCrypto.WeeklyAverages select u).ToList();
            List<Cryptocurrency> cryptos = (from u in dbCrypto.Cryptocurrencies select u).ToList();


            var coefList = new List<decimal>();


            foreach (var item in cryptos)
            {
                var crypt = from t in cryptos
                            where t.Name == item.Name
                            orderby t.MarketCap descending
                            select (double)t.PriceUSD;

                double mean = (double)crypt.Average();
                double std = Math.Sqrt(crypt.Sum(x => Math.Pow(x - mean, 2)) / crypt.Count());
                double coef = std / mean * 100;


                coefList.Add((decimal)coef);
            }

            





        }

        private decimal CalculateCoef()
        {
            decimal coef = 0.0M;
            return coef;
        }


        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.DAL;
using System.Data.Entity.SqlServer;

namespace CA.BL
{
    public class WeeklyAverageCreator
    {
        public void WeeklyAverages()
        {
            MainContext dbCrypto = new MainContext();
            List<Cryptocurrency> cryptos = (from u in dbCrypto.Cryptocurrencies select u).ToList();
            var list = new List<WeeklyAverage>();
            DateTime BackTime = DateTime.Now.AddDays(-5);

            var avgs = from t in cryptos
                       where t.TimeStamp >= BackTime
                       orderby t.MarketCap descending
                       group t by t.Name into g
                       select new
                       {
                           Name = g.Key,
                           WeeklyAvgMarketCap = g.Average(n => n.MarketCap),
                           WeeklyAvgPriceUSD = g.Average(n => n.PriceUSD),
                           WeeklyAvgDailyVolume = g.Average(n => n.DailyVolume)
                       };

            foreach (var item in avgs)
            {
                list.Add(new WeeklyAverage
                {
                    Name = item.Name,
                    WeeklyAvgMarketCap = item.WeeklyAvgMarketCap,
                    WeeklyAvgPriceUSD = item.WeeklyAvgPriceUSD,
                    WeeklyAvgDailyVolume = item.WeeklyAvgDailyVolume,
                    TimeStamp = DateTime.Now
                });
            }
       
            dbCrypto.WeeklyAverages.AddRange(list);
            dbCrypto.SaveChanges();
            dbCrypto.Dispose();
        }
    }
}




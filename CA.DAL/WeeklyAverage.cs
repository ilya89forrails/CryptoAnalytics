using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.DAL
{
    public class WeeklyAverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal WeeklyAvgMarketCap { get; set; }
        public decimal WeeklyAvgPriceUSD { get; set; }
        public decimal WeeklyAvgDailyVolume { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

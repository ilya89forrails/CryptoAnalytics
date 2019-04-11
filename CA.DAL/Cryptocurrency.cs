using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.DAL
{
    public class Cryptocurrency
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal MarketCap { get; set; }
        public decimal PriceUSD { get; set; }
        public decimal DailyVolume { get; set; }
        public decimal CirculatingSupply { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

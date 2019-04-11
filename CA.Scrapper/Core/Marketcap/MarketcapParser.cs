using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using CA.DAL;

namespace CA.Scrapper.Core.Marketcap
{
    public class MarketcapParser : IParser<Cryptocurrency[]>
    {
        public Cryptocurrency[] Parse(IHtmlDocument document)
        {
            var list = new List<Cryptocurrency>();

            var Ranks = document.QuerySelectorAll("td").Where(m => m.ClassName != null && m.ClassName.Contains("text-center"));
            var Names = document.QuerySelectorAll("a").Where(m => m.ClassName != null && m.ClassName.Contains("currency-name-container"));
            var Symbols = document.QuerySelectorAll("td").Where(m => m.ClassName != null && m.ClassName.Contains("text-left col-symbol"));
            //var MarketCaps = document.QuerySelectorAll("td").Where(m => m.ClassName != null && m.ClassName.Contains("no-wrap market-cap text-right"));
            //var PricesUSD = document.QuerySelectorAll("a").Where(m => m.ClassName != null && m.ClassName.Contains("price"));
            //var DailyVolumes = document.QuerySelectorAll("a").Where(m => m.ClassName != null && m.ClassName.Contains("volume"));
            //var CirculatingSupplies = document.QuerySelectorAll("span").Where(m => m.GetAttribute("data-supply") != null);

            for (int i = 0; i<Ranks.Count(); i++) {
                list.Add(new Cryptocurrency
                {
                    Rank = Int32.Parse(Ranks.ElementAt(i).TextContent),
                    Name = Names.ElementAt(i).TextContent,
                    Symbol = Symbols.ElementAt(i).TextContent,
                    //MarketCap = Decimal.Parse(MarketCaps.ElementAt(i).TextContent),
                    //PriceUSD = Decimal.Parse(PricesUSD.ElementAt(i).TextContent),
                    //DailyVolume = Decimal.Parse(DailyVolumes.ElementAt(i).TextContent),
                    //CirculatingSupply = Decimal.Parse(CirculatingSupplies.ElementAt(i).TextContent),
                    //TimeStamp = DateTime.Now
                });
            }


            CryptocurrencyContext db = new CryptocurrencyContext();

            foreach (var item in list)
            {
                db.Cryptocurrencies.Add(item);
                
            }
                db.SaveChanges();





            return list.ToArray();    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;
using CA.DAL;
using System.Globalization;

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
            var MarketCaps = document.QuerySelectorAll("td").Where(m => m.ClassName != null && m.ClassName.Contains("no-wrap market-cap text-right"));
            var PricesUSD = document.QuerySelectorAll("a").Where(m => m.ClassName != null && m.ClassName.Contains("price"));
            var DailyVolumes = document.QuerySelectorAll("a").Where(m => m.ClassName != null && m.ClassName.Contains("volume"));
            var CirculatingSupplies = document.QuerySelectorAll("span").Where(m => m.GetAttribute("data-supply") != null);

            for (int i = 0; i<Ranks.Count(); i++) {
                list.Add(new Cryptocurrency
                {
                    Rank = Int32.Parse(Ranks.ElementAt(i).TextContent),
                    Name = Names.ElementAt(i).TextContent,
                    Symbol = Symbols.ElementAt(i).TextContent,
                    MarketCap = GetElements(MarketCaps, i),
                    PriceUSD = GetElements(PricesUSD, i),
                    DailyVolume = GetElements(DailyVolumes, i),
                    CirculatingSupply = GetElements(CirculatingSupplies, i),
                    TimeStamp = DateTime.Now
                });
            }

            MainContext db = new MainContext();

            db.Cryptocurrencies.AddRange(list);
            db.SaveChanges();
            db.Dispose();

            return list.ToArray();    
        }

        private decimal GetElements(IEnumerable<AngleSharp.Dom.IElement> Elements, int i)
        {
            try
            {
                return Decimal.Parse(Elements.ElementAt(i).TextContent.Replace("$", string.Empty).Replace("*", string.Empty).Replace(",", string.Empty).Replace("?", "0M").Replace(" ", string.Empty), CultureInfo.InvariantCulture);
            }
            catch (System.FormatException)
            {
                return 0.0M;
            }
        }
    }
}

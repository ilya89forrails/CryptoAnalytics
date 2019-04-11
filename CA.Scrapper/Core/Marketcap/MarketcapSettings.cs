using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace CA.Scrapper.Core.Marketcap
{
    public class MarketcapSettings : IParserSettings
    {
        public MarketcapSettings(int start, int end) {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://coinmarketcap.com/";

        public string Prefix { get; set; } = "all/views/all/";

        public int StartPoint { get; set; }

        public int EndPoint { get; set; }
    }
}

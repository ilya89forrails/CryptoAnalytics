using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.DAL
{
    public class Test
    {
        public static void Run()
        {

            using (CryptocurrencyContext db = new CryptocurrencyContext())
            {
                Cryptocurrency bitcoin = new Cryptocurrency { Name = "Tom", Rank = 1};
                Cryptocurrency ethereum = new Cryptocurrency { Name = "Sam", Rank = 2, PriceUSD = 200 };

                db.Cryptocurrencies.Add(bitcoin);
                db.Cryptocurrencies.Add(ethereum);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                var users = db.Cryptocurrencies;
                Console.WriteLine("Список объектов:");
                foreach (Cryptocurrency u in users)
                {
                    //Console.WriteLine("{0}.{1} - {2}{3}", u.Rank, u.Name, u.HourlyChange, u.PriceUSD);
                }
            }
        }
    }
}

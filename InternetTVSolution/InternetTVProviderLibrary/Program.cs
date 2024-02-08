using InternetTVProviderLibrary.FacadePattern;
using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.SingletonPattern;
using InternetTVProviderLibrary.StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary
{
     class Program
    {
        static void Main()
        {
            StrategyContext context = new StrategyContext();

            ScanConfiguration scanConfig = new ScanConfiguration();
            context.setStrategy(scanConfig);
            context.ExecuteStrategy();

            ConnectToDatabase connection = new ConnectToDatabase();
            context.setStrategy(connection);
            context.ExecuteStrategy();
            //za kombinovani paket mora da se stavi da se nadje cena od tv i internet paketa i da se setuje njihov zbir
         /*   QueryFacade facade = new QueryFacade(DatabaseManager.Instance.Connection);

            facade.addNewTVPackage("NOVI tv paket", 1000, 500, 1);
            facade.addNewInternetPackage("NOVI internet paket", 500, "500 mbps", 2);
            facade.addNewCombinedPackage("NOVI kombinovaniPaket", 4, 4, 3);

            TVPackage tvpackage = facade.getTVPackageByPackageID(4);
            InternetPackage internetPackage = facade.getInternetPackageByPackageID(4);
            CombinedPackage combinedPackage = facade.getCombinedPackageByPackageID(5);

            Console.WriteLine("TV PAKET: ---------------- \n");
            Console.WriteLine(tvpackage.Name + " " + tvpackage.Price + " " + tvpackage.NumberOfChannels + "\n");

            Console.WriteLine("INTERNET PAKET: ---------------- \n");
            Console.WriteLine(internetPackage.Name + " " + internetPackage.Price + " " + internetPackage.InternetSpeed + "\n");

            Console.WriteLine("KOMBINOVANI PAKET: ---------------- \n");
            Console.WriteLine(combinedPackage.Name + " " + combinedPackage.Price + " " + combinedPackage.InternetPackageId + " " + combinedPackage.TVPackageId + "\n");
         */

            Console.ReadLine();
        }

    }
}

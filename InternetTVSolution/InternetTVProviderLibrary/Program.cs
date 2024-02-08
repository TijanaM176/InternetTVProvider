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

            //QueryFacade facade = new QueryFacade(DatabaseManager.Instance.Connection);

            //Console.ReadLine();
        }

    }
}

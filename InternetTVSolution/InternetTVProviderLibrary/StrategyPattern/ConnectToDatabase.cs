using InternetTVProviderLibrary.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    public class ConnectToDatabase : IStrategy
    {
        public void execute()
        {
            try
            {
                if (ScanConfiguration.configurationString == "")
                {
                    Console.WriteLine("Greška prilikom čitanja konfiguracionog fajla!");
                    return;
                }

                Console.WriteLine("Naziv provajdera: " + ScanConfiguration.providerName);
                Console.WriteLine("Konekcioni string: " + ScanConfiguration.configurationString);

                if (ScanConfiguration.configurationString.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
                {
                    DatabaseManager.Instance.ConnectToDatabase("sqlite", ScanConfiguration.configurationString);
                }
                else if (ScanConfiguration.configurationString.StartsWith("server=", StringComparison.OrdinalIgnoreCase))
                {
                    DatabaseManager.Instance.ConnectToDatabase("mysql", ScanConfiguration.configurationString);
                }
                else
                {
                    Console.WriteLine("Nepodržan format konekcionog stringa!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška pri konekciji sa bazom: " + ex.Message);
            }
        }

    }
}

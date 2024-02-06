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

            /*
            DatabaseManager databaseManager = DatabaseManager.Instance;

            //MYSQL
            string connectionString = "server=localhost;user=root;password=;database=InternetTVProvider";
            databaseManager.ConnectToDatabase("mysql", connectionString);


            //SQLite
            string databasePath = @"C:\Users\risti\OneDrive\Desktop\database\InternetTVProvider.db";
            string sqliteConnectionString = "Data Source="+databasePath+";Version=3;";
            databaseManager.ConnectToDatabase("sqlite", sqliteConnectionString);
            */
            /*
            StrategyContext context = new StrategyContext();

            ScanConfiguration scanConfig = new ScanConfiguration();
            context.setStrategy(scanConfig);    
            context.ExecuteStrategy();    

            StrategyMySQL csMySQL = new StrategyMySQL(ScanConfiguration.configurationPath);
            context.setStrategy(csMySQL);
            context.ExecuteStrategy();
            */

            static bool ReadConfigFile(out string providerName, out string connectionString)
            {
                string configFilePath = "C:\\Users\\risti\\OneDrive\\Desktop\\ds\\tim-13\\InternetTVSolution\\InternetTVProviderLibrary\\config.txt";

                if (!File.Exists(configFilePath))
                {
                    providerName = null;
                    connectionString = null;
                    return false;
                }

                string[] lines = File.ReadAllLines(configFilePath);

                if (lines.Length < 2)
                {
                    providerName = null;
                    connectionString = null;
                    return false;
                }

                providerName = lines[0].Trim();
                connectionString = lines[1].Trim();
                return true;
            }

            string providerName, connectionString;

            if (ReadConfigFile(out providerName, out connectionString))
            {
                Console.WriteLine("Naziv provajdera: " + providerName);
                Console.WriteLine("Konekcioni string: " + connectionString);
                if (connectionString.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
                {
                    DatabaseManager.Instance.ConnectToDatabase("sqlite", connectionString);
                }
                else if (connectionString.StartsWith("server=", StringComparison.OrdinalIgnoreCase))
                {
                    DatabaseManager.Instance.ConnectToDatabase("mysql", connectionString);
                }
                else
                {
                    Console.WriteLine("Nepodržan format konekcionog stringa.");
                }


            }
            else
            {
                Console.WriteLine("Greška prilikom čitanja konfiguracionog fajla.");
            }


        }


    }
}

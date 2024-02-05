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
                
                StrategyContext context = new StrategyContext();

                ScanConfiguration scanConfig = new ScanConfiguration();
                context.setStrategy(scanConfig);    
                context.ExecuteStrategy();    

                StrategyMySQL csMySQL = new StrategyMySQL(ScanConfiguration.configurationPath);
                context.setStrategy(csMySQL);
                context.ExecuteStrategy();
                
        }


    }
}

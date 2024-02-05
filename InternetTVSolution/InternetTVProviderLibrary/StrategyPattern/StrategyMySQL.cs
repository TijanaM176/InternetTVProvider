using InternetTVProviderLibrary.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    public class StrategyMySQL : IStrategy
    {
        private DatabaseManager databaseMenager;
        private string connectionString;

        public StrategyMySQL(String connectionPath)
        {
            connectionString = connectionPath;
            databaseMenager = DatabaseManager.Instance;
        }

        public void setConnectionString(String connectionPath)
        {
            connectionString = connectionPath;
        }

        public void connectSQL()
        {
            try
            {
                databaseMenager.ConnectToDatabase("mysql", connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška pri konekciji sa bazom: " + ex.Message);
            }
        }

    }
}

using InternetTVProviderLibrary.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    public class ConcreteStrategySQLite : IStrategy
    {
        private DatabaseManager databaseMenager;
        private string connectionString;

        public ConcreteStrategySQLite(String connectionPath)
        {
            connectionString = "Data Source=" + connectionPath + ";Version=3;";
            databaseMenager = DatabaseManager.Instance;
        }

        public void setConnectionString(String connectionPath)
        {
            connectionString = "Data Source=" + connectionPath + ";Version=3;";
        }

        public void connectSQL()
        {
            try
            {
                databaseMenager.ConnectToDatabase("sqlite", connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška pri konekciji sa bazom: " + ex.Message);
            }
        }

    }
}

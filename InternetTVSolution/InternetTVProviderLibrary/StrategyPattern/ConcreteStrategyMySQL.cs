using InternetTVProviderLibrary.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.StrategyPattern
{
    public class ConcreteStrategyMySQL : IStrategy
    {
        private DatabaseMenager databaseMenager;
        private string connectionString;

        public ConcreteStrategyMySQL(String connectionPath)
        {
            connectionString = connectionPath;
            databaseMenager = DatabaseMenager.Instance;
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

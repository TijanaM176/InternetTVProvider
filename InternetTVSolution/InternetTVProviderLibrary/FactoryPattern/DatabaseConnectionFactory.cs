using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.FactoryPattern
{
    public  class DatabaseConnectionFactory 
    {
        public static IDatabaseConnectionFactory getConnection(string databaseType, string connectionString)
        {
            switch (databaseType.ToLower())
            {
                case "mysql":
                    return new MySqlConnectionFactory(connectionString);
                case "sqlite":
                    return new SQLiteConnectionFactory(connectionString);
                default:
                    throw new Exception("Nepodržana vrsta baze podataka.");
            }
        }

    }
}

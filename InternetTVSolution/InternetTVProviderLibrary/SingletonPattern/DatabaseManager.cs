using System;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data.Common;
using InternetTVProviderLibrary.FactoryPattern;

namespace InternetTVProviderLibrary.SingletonPattern
{


    public class DatabaseManager
    {
        private static DatabaseManager _instance;
        private static readonly object _lockObject = new object();
        private string _connectionString;
        public DbConnection Connection { get; set; }
        private IDatabaseConnectionFactory _factory;

        private DatabaseManager() { }

        public static DatabaseManager Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseManager();
                    }
                }
                return _instance;
            }
        }

        public void ConnectToDatabase(string databaseType, string connectionString)
        {
            _connectionString = connectionString;

            _factory = DatabaseConnectionFactory.getConnection(databaseType, connectionString);

            ConnectToDatabase();
        }

        private void ConnectToDatabase()
        {
            try
            {
                    DbConnection connection = _factory.CreateConnection();
                    connection.Open();
                    Connection = connection;
                    Console.WriteLine($"Connected to {_factory.GetType().Name} database.");
                    _factory.InitializeTables();
                    _factory.InsertDataInTables();
             
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
            }
        }

        
    }


}







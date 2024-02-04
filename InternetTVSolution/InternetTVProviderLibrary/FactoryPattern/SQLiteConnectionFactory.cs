using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.FactoryPattern
{
    public class SQLiteConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;
        private DbConnection _connection;

        public SQLiteConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public void InitializeTables()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine($"Connected to SQLite database for table initialization.");

                    string createPackagesTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Packages (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price DECIMAL(10, 2) NOT NULL,
                        InternetSpeed INT NOT NULL,
                        NumberOfChannels INT NOT NULL,
                        TypeID INT NOT NULL,
                        CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        UpdatedAt DATETIME DEFAULT NULL
                    );
                ";

                    string createClientsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Clients (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        UpdatedAt DATETIME DEFAULT NULL
                    );
                ";

                    string createTypeTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Type (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        TypeName TEXT NOT NULL
                    );
                ";

                    string createSubscriptionsTableQuery = @"
                CREATE TABLE IF NOT EXISTS Subscriptions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT
                );
            ";

                    using (SQLiteCommand command = new SQLiteCommand(createPackagesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createClientsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createTypeTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createSubscriptionsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("SQLite tables initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing SQLite tables: {ex.Message}");
            }
        }
    }

}

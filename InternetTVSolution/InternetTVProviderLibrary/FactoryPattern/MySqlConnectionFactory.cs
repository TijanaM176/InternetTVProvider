using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.FactoryPattern
{
    public class MySqlConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;
        private DbConnection _connection;

        public MySqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public void InitializeTables()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine($"Connected to MySQL database for table initialization.");

                    string createPackagesTableQuery = @"
                CREATE TABLE IF NOT EXISTS Packages (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    Name VARCHAR(255) NOT NULL,
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
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    Username VARCHAR(255) NOT NULL,
                    FirstName VARCHAR(255) NOT NULL,
                    LastName VARCHAR(255) NOT NULL,
                    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    UpdatedAt DATETIME DEFAULT NULL
                );
            ";

                    string createTypeTableQuery = @"
                CREATE TABLE IF NOT EXISTS Type (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    TypeName VARCHAR(50) NOT NULL
                );
            ";

                    string createSubscriptionsTableQuery = @"
                CREATE TABLE IF NOT EXISTS Subscriptions (
                    Id INT PRIMARY KEY AUTO_INCREMENT
                );
            ";

                    using (MySqlCommand command = new MySqlCommand(createPackagesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createClientsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createTypeTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createSubscriptionsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("MySQL tables initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing MySQL tables: {ex.Message}");
            }
        }

    }

}

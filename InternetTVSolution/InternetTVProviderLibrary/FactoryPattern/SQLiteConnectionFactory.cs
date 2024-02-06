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

                    string createClientsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Clients (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL
                    );
                ";

                    string createPackagesTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Packages (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price DECIMAL(10, 2) NOT NULL
                    );
                ";

                   string createTVPackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS TVPackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PackageId INT NOT NULL,
                        NumberOfChannels INT NOT NULL,
                        FOREIGN KEY (PackageId) REFERENCES Package(Id)
                    );
                ";

                    string createInternetPackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS InternetPackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PackageId INT NOT NULL,
                        InternetSpeed VARCHAR(50) NOT NULL,
                        FOREIGN KEY (PackageId) REFERENCES Package(Id)
                    );
                ";

                    string createCombinePackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS CombinePackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PackageId INT NOT NULL,
                        TVPackageId INT NOT NULL,
                        InternetPackageId INT NOT NULL,
                        FOREIGN KEY (PackageId) REFERENCES Package(Id),
                        FOREIGN KEY (TVPackageId) REFERENCES TVPackage(Id),
                        FOREIGN KEY (InternetPackageId) REFERENCES InternetPackage(Id)
                    );
                ";


                    string createProviderTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Provider (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClientId INT NOT NULL,
                        PackageId INT NOT NULL,
                        FOREIGN KEY (ClientId) REFERENCES Client(Id),
                        FOREIGN KEY (PackageId) REFERENCES Package(Id)
                );
            ";

                    using (SQLiteCommand command = new SQLiteCommand(createClientsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createPackagesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createTVPackageTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createInternetPackageTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createCombinePackageTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(createProviderTableQuery, connection))
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

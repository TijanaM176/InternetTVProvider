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

                    string createClientsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Clients (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Username VARCHAR(255) NOT NULL,
                            FirstName VARCHAR(255) NOT NULL,
                            LastName VARCHAR(255) NOT NULL
                        );
                    ";

                    string createPackagesTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Packages (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL
                        );
                    ";

                     string createTVPackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS TVPackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            PackageId INT NOT NULL,
                            NumberOfChannels INT NOT NULL,
                            FOREIGN KEY (PackageId) REFERENCES Packages(Id)
                        );
                    ";

                     string createInternetPackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS InternetPackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            PackageId INT NOT NULL,
                            InternetSpeed VARCHAR(50) NOT NULL,
                            FOREIGN KEY (PackageId) REFERENCES Packages(Id)
                        );
                    ";

                     string createCombinePackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS CombinePackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            PackageId INT NOT NULL,
                            TVPackageId INT NOT NULL,
                            InternetPackageId INT NOT NULL,
                            FOREIGN KEY (PackageId) REFERENCES Packages(Id),
                            FOREIGN KEY (TVPackageId) REFERENCES TVPackage(Id),
                            FOREIGN KEY (InternetPackageId) REFERENCES InternetPackage(Id)
                        );
                    ";

                      string createProviderTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Provider (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            ClientId INT NOT NULL,
                            PackageId INT NOT NULL,
                            FOREIGN KEY (ClientId) REFERENCES Clients(Id),
                            FOREIGN KEY (PackageId) REFERENCES Packages(Id)
                        );
                    ";


                    using (MySqlCommand command = new MySqlCommand(createClientsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createPackagesTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createTVPackageTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createInternetPackageTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createCombinePackageTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(createProviderTableQuery, connection))
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

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
                            Name VARCHAR(255) NOT NULL
                        );
                    ";

                     string createTVPackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS TVPackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
                            PackageId INT NOT NULL,
                            NumberOfChannels INT NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL,
                            FOREIGN KEY (PackageId) REFERENCES Packages(Id)
                        );
                    ";

                     string createInternetPackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS InternetPackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
                            PackageId INT NOT NULL,
                            InternetSpeed VARCHAR(50) NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL,
                            FOREIGN KEY (PackageId) REFERENCES Packages(Id)
                        );
                    ";

                     string createCombinePackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS CombinePackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
                            PackageId INT NOT NULL,
                            TVPackageId INT NOT NULL,
                            InternetPackageId INT NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL,
                            FOREIGN KEY (PackageId) REFERENCES Packages(Id),
                            FOREIGN KEY (TVPackageId) REFERENCES TVPackage(Id),
                            FOREIGN KEY (InternetPackageId) REFERENCES InternetPackage(Id)
                        );
                    ";

                      string createProviderTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Provider (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
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


        public void InsertDataInTables()
        {

            try
            {
                
                    using (MySqlConnection connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();
                        Console.WriteLine($"Connected to MySQL database for data insertion.");

                        string insertClientsQuery = @"
                            INSERT INTO Clients (Username, FirstName, LastName) VALUES
                            ('ana_simic', 'Ana', 'Simic'),
                            ('petar_peric', 'Petar', 'Peric'),
                            ('jana_mikic', 'Jana', 'Mikic'),
                            ('sava_savic', 'Sava', 'Savic'),
                            ('marko_petrovic', 'Marko', 'Petrovic');
                        ";

                        string insertPackagesQuery = @"
                            INSERT INTO Packages (Name) VALUES
                            ('TV package'),
                            ('Internet package'),
                            ('Combine package');
                        ";

                        string insertTVPackageQuery = @"
                        INSERT INTO TVPackage (Name, PackageId, NumberOfChannels, Price) VALUES
                        ('Basic TV Package', 1, 100, 29.99),
                        ('Standard TV Package', 1, 150, 39.99),
                        ('Premium TV Package', 1, 250, 49.99);
                    ";

                        string insertInternetPackageQuery = @"
                        INSERT INTO InternetPackage (Name, PackageId, InternetSpeed, Price) VALUES
                        ('Basic Internet Package ', 2, '100 Mbps', 49.99),
                        ('Standard Internet Package ', 2, '200 Mbps', 59.99),
                        ('Premium Internet Package ', 2, '300 Mbps', 69.99);
                    ";

                        string insertCombinePackageQuery = @"
                        INSERT INTO CombinePackage (Name, PackageId, TVPackageId, InternetPackageId, Price) VALUES
                        ('Basic Combine Package ', 3, 1, 1, 69.99),
                        ('Standard Combine Package ', 3, 2, 2, 79.99),
                        ('Preminum Combine Package ', 3, 2, 3, 89.99),
                        ('Super Preminum Combine Package ', 3, 3, 3, 99.99);
                    ";

                        string insertProviderQuery = @"
                        INSERT INTO Provider (Name, ClientId, PackageId) VALUES
                        ('SBB ', 2, 2);
                    ";



                        using (MySqlCommand command = new MySqlCommand(insertClientsQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(insertPackagesQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(insertTVPackageQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(insertInternetPackageQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(insertCombinePackageQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(insertProviderQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }



                        Console.WriteLine("Data inserted into MySQL tables.");
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into MySQL tables: {ex.Message}");
            }
        }

     

    }


}



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

                    string createPackageTypeTableQuery = @"
                        CREATE TABLE IF NOT EXISTS PackageType (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL
                        );
                    ";

                    string createTVPackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS TVPackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL,
                            NumberOfChannels INT NOT NULL,
                            TypeID INT NOT NULL,
                            FOREIGN KEY (TypeID) REFERENCES PackageType(Id)
                        );
                    ";

                     string createInternetPackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS InternetPackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL,
                            InternetSpeed VARCHAR(50) NOT NULL,
                            TypeID INT NOT NULL,
                            FOREIGN KEY (TypeID) REFERENCES PackageType(Id)
                        );
                    ";

                     string createCombinePackageTableQuery = @"
                        CREATE TABLE IF NOT EXISTS CombinePackage (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Name VARCHAR(255) NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL,
                            TVPackageId INT NOT NULL,
                            InternetPackageId INT NOT NULL,
                            TypeID INT NOT NULL,
                            FOREIGN KEY (TypeID) REFERENCES PackageType(Id),
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

                      string createSubscriptionsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Subscriptions (
                            Id INT PRIMARY KEY AUTO_INCREMENT,
                            Client_ID INT NOT NULL,
                            Packet_ID INT NOT NULL,
                            TypeID INT NOT NULL,
                            Activated BOOL NOT NULL,
                            FOREIGN KEY (Client_ID) REFERENCES Clients(Id),
                            FOREIGN KEY (Packet_ID) REFERENCES Packages(Id),
                            FOREIGN KEY (TypeID) REFERENCES PackageType(Id)
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

                    using (MySqlCommand command = new MySqlCommand(createPackageTypeTableQuery, connection))
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

                        string insertPackageTypeQuery = @"
                            INSERT INTO PackageType (Name) VALUES
                            ('TV package'),
                            ('Internet package'),
                            ('Combine package');
                        ";

                    string insertTVPackageQuery = @"
                        INSERT INTO TVPackage (Name, Price, NumberOfChannels, TypeID) VALUES
                        ('Basic TV Package', 29.99, 100, 1),
                        ('Standard TV Package', 39.99, 150, 1),
                        ('Premium TV Package', 49.99, 250, 1);
                    ";

                        string insertInternetPackageQuery = @"
                        INSERT INTO InternetPackage (Name, Price, InternetSpeed, TypeID) VALUES
                        ('Basic Internet Package ', 49.99, '100 Mbps', 2),
                        ('Standard Internet Package ', 59.99, '200 Mbps', 2),
                        ('Premium Internet Package ', 69.99, '300 Mbps', 2);
                    ";

                        string insertCombinePackageQuery = @"
                        INSERT INTO CombinePackage (Name, Price, TVPackageId, InternetPackageId, TypeID) VALUES
                        ('Basic Combine Package ', 69.99, 1, 1, 3),
                        ('Standard Combine Package ', 79.99, 2, 2, 3),
                        ('Preminum Combine Package ', 89.99, 2, 3, 3),
                        ('Super Preminum Combine Package ', 99.99, 3, 3, 3);
                    ";

                        string insertProviderQuery = @"
                        INSERT INTO Provider (Name, ClientId, PackageId) VALUES
                        ('SBB ', 2, 2);
                    ";

                    string insertSubscriptionsQuery = @"
                        INSERT INTO Subscriptions (Client_ID, Packet_ID, TypeID, Activated) VALUES
                        (1, 1, 1, 1),
                        (2, 2, 2, 1),
                        (3, 3, 3, 1);
                    ";



                    using (MySqlCommand command = new MySqlCommand(insertClientsQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(insertPackagesQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(insertPackageTypeQuery, connection))
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

                    using (MySqlCommand command = new MySqlCommand(insertSubscriptionsQuery, connection))
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



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
                            Name VARCHAR(255) NOT NULL,
                            Price DECIMAL(10, 2) NOT NULL,
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
                        INSERT INTO Subscriptions (Client_ID, Packet_ID, Name, Price, TypeID, Activated) VALUES
                        (1, 1, 'Basic TV Package', 29.99, 1, 1),
                        (1, 3, 'Premium Internet Package ', 69.99, 2, 1),
                        (1, 2, 'Standard Combine Package ', 79.99, 3, 0),
                        (2, 2, 'Standard Internet Package ', 59.99, 2, 1),
                        (3, 3,'Preminum Combine Package ', 89.99, 3, 1);
                    ";

                    string checkClientsQuery = "SELECT COUNT(*) FROM Clients";
                    using (MySqlCommand command = new MySqlCommand(checkClientsQuery, connection))
                    {
                        int clientCount = Convert.ToInt32(command.ExecuteScalar());
                        if (clientCount == 0) { 
                            using (MySqlCommand command1 = new MySqlCommand(insertClientsQuery, connection))
                            {
                                command1.ExecuteNonQuery();
                            }
                        }
                    }

                    string checkPackagesQuery = "SELECT COUNT(*) FROM Packages";
                    using (MySqlCommand command = new MySqlCommand(checkPackagesQuery, connection))
                    {
                        int packageCount = Convert.ToInt32(command.ExecuteScalar());
                        if (packageCount == 0)
                        {

                            using (MySqlCommand command1 = new MySqlCommand(insertPackagesQuery, connection))
                        {
                            command1.ExecuteNonQuery();
                        }
                        }
                    }
                    string checkPackagesTypeQuery = "SELECT COUNT(*) FROM PackageType";
                    using (MySqlCommand command = new MySqlCommand(checkPackagesTypeQuery, connection))
                    {
                        int packagetypeCount = Convert.ToInt32(command.ExecuteScalar());
                        if (packagetypeCount == 0)
                        {
                            using (MySqlCommand command1 = new MySqlCommand(insertPackageTypeQuery, connection))
                        {
                            command1.ExecuteNonQuery();
                        }
                        }
                    }


                    string checkTVPackagesQuery = "SELECT COUNT(*) FROM TVPackage;";
                    using (MySqlCommand command = new MySqlCommand(checkTVPackagesQuery, connection))
                    {
                        int tvpackCount = Convert.ToInt32(command.ExecuteScalar());
                        if (tvpackCount == 0)
                        {
                            using (MySqlCommand command1 = new MySqlCommand(insertTVPackageQuery, connection))
                            {
                                command1.ExecuteNonQuery();
                            }
                        }
                    }
                    string checkInternetPackagesQuery = "SELECT COUNT(*) FROM InternetPackage;";
                    using (MySqlCommand command = new MySqlCommand(checkInternetPackagesQuery, connection))
                    {
                        int internetpackCount = Convert.ToInt32(command.ExecuteScalar());
                        if (internetpackCount == 0)
                        {
                            using (MySqlCommand command1 = new MySqlCommand(insertInternetPackageQuery, connection))
                            {
                                command1.ExecuteNonQuery();
                            }
                        }
                    }
                    string checkCombinedPackagesQuery = "SELECT COUNT(*) FROM CombinePackage;";
                    using (MySqlCommand command = new MySqlCommand(checkCombinedPackagesQuery, connection))
                    {
                        int cominedpackCount = Convert.ToInt32(command.ExecuteScalar());
                        if (cominedpackCount == 0)
                        {
                            using (MySqlCommand command1 = new MySqlCommand(insertCombinePackageQuery, connection))
                            {
                                command1.ExecuteNonQuery();
                            }
                        }
                    }
                    string checkProviderPackagesQuery = "SELECT COUNT(*) FROM Provider;";
                    using (MySqlCommand command = new MySqlCommand(checkProviderPackagesQuery, connection))
                    {
                        int providerCount = Convert.ToInt32(command.ExecuteScalar());
                        if (providerCount == 0)
                        {
                            using (MySqlCommand command1 = new MySqlCommand(insertProviderQuery, connection))
                            {
                                command1.ExecuteNonQuery();
                            }
                        }
                    }
                    string checkSubsQuery = "SELECT COUNT(*) FROM Subscriptions;";
                    using (MySqlCommand command = new MySqlCommand(checkSubsQuery, connection))
                    {
                        int SubsCount = Convert.ToInt32(command.ExecuteScalar());
                        if (SubsCount == 0)
                        {
                            using (MySqlCommand command1 = new MySqlCommand(insertSubscriptionsQuery, connection))
                            {
                                command1.ExecuteNonQuery();
                            }
                        }
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



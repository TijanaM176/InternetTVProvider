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
                        Name TEXT NOT NULL
                    );
                ";

                    string createPackageTypeTableQuery = @"
                    CREATE TABLE IF NOT EXISTS PackageType (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL
                    );
                ";

                    string createTVPackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS TVPackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL, 
                        NumberOfChannels INT NOT NULL,
                        TypeID INT NOT NULL, 
                        FOREIGN KEY (TypeID) REFERENCES PackageType(Id)
                    );
                ";

                    string createInternetPackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS InternetPackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL,
                        InternetSpeed VARCHAR(50) NOT NULL,
                        TypeID INT NOT NULL,
                        FOREIGN KEY (TypeID) REFERENCES PackageType(Id)
                    );
                ";

                    string createCombinePackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS CombinePackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL,                       
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
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        ClientId INT NOT NULL,
                        PackageId INT NOT NULL,
                        FOREIGN KEY (ClientId) REFERENCES Client(Id),
                        FOREIGN KEY (PackageId) REFERENCES Packages(Id),
                        FOREIGN KEY (PackageId) REFERENCES Package(Id)
                );
            ";

                    string createSubscriptionsTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Subscriptions (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Client_ID INT NOT NULL,
                            Packet_ID INT NOT NULL,
                            TypeID INT NOT NULL,
                            Activated BOOL NOT NULL,
                            FOREIGN KEY (Client_ID) REFERENCES Clients(Id),
                            FOREIGN KEY (TypeID) REFERENCES PackageType(Id)
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

                    using (SQLiteCommand command = new SQLiteCommand(createPackageTypeTableQuery, connection))
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

        public void InsertDataInTables()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine($"Connected to SQLite database for data insertion.");

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
                        ('SBB', 2, 2);
                    ";

                    string insertSubscriptionsQuery = @"
                        INSERT INTO Subscriptions (Client_ID, Packet_ID, TypeID, Activated) VALUES
                        (1, 1, 1, 1),
                        (2, 2, 2, 1),
                        (3, 3, 3, 1);
                    ";

                    using (SQLiteCommand command = new SQLiteCommand(insertClientsQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertPackagesQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertPackageTypeQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertTVPackageQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertInternetPackageQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertCombinePackageQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertProviderQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertSubscriptionsQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Data inserted into SQLite tables.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into SQLite tables: {ex.Message}");
            }
        }
    }

}

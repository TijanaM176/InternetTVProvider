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

                   string createTVPackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS TVPackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        PackageId INT NOT NULL,
                        NumberOfChannels INT NOT NULL,
                        Price REAL NOT NULL, 
                        FOREIGN KEY (PackageId) REFERENCES Package(Id)
                    );
                ";

                    string createInternetPackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS InternetPackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        PackageId INT NOT NULL,
                        InternetSpeed VARCHAR(50) NOT NULL,
                        Price REAL NOT NULL,
                        FOREIGN KEY (PackageId) REFERENCES Package(Id)
                    );
                ";

                    string createCombinePackageTableQuery = @"
                    CREATE TABLE IF NOT EXISTS CombinePackage (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        PackageId INT NOT NULL,
                        TVPackageId INT NOT NULL,
                        InternetPackageId INT NOT NULL,
                        Price REAL NOT NULL,
                        FOREIGN KEY (PackageId) REFERENCES Package(Id),
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

                    string insertTVPackageQuery = @"
                        INSERT INTO TVPackage (Name, PackageId, NumberOfChannels, Price) VALUES
                        ('Basic TV Package', 1, 100, 29.99),
                        ('Standard TV Package', 1, 150, 39.99),
                        ('Premium TV Package', 1, 250, 49.99);
                    ";

                    string insertInternetPackageQuery = @"
                        INSERT INTO InternetPackage (Name, PackageId, InternetSpeed, Price) VALUES
                        ('Basic Internet Package', 2, '100 Mbps', 49.99),
                        ('Standard Internet Package', 2, '200 Mbps', 59.99),
                        ('Premium Internet Package', 2, '300 Mbps', 69.99);
                    ";

                    string insertCombinePackageQuery = @"
                        INSERT INTO CombinePackage (Name, PackageId, TVPackageId, InternetPackageId, Price) VALUES
                        ('Basic Combine Package', 3, 1, 1, 69.99),
                        ('Standard Combine Package', 3, 2, 2, 79.99),
                        ('Premium Combine Package', 3, 2, 3, 89.99),
                        ('Super Premium Combine Package', 3, 3, 3, 99.99);
                    ";

                    string insertProviderQuery = @"
                        INSERT INTO Provider (Name, ClientId, PackageId) VALUES
                        ('SBB', 2, 2);
                    ";

                    using (SQLiteCommand command = new SQLiteCommand(insertClientsQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(insertPackagesQuery, connection))
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

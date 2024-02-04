using System;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Data.Common;

namespace InternetTVProviderLibrary.SingletonPattern
{
 

        internal class DatabaseMenager
        {
            private static DatabaseMenager _instance;
            private static readonly object _lockObject = new object();
            private string _connectionString;
            public DbConnection Connection { get; set; }

        private DatabaseMenager()
            {

            }

            public static DatabaseMenager Instance
            {
                get
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseMenager();
                        }
                    }
                    return _instance;
                }
            }

            public void ConnectToDatabase(string databaseType, string connectionString)
            {
                _connectionString = connectionString;

                switch (databaseType.ToLower())
                {
                    case "mysql":
                        ConnectToMySQL();
                        break;
                    case "sqlite":
                        ConnectToSQLite();
                        break;
                    default:
                        Console.WriteLine("Nepodržana vrsta baze podataka.");
                        break;
                }
            }

            private void ConnectToMySQL()
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();
                        Connection = connection;
                        Console.WriteLine("Connected to MySQL database.");
                        InitializeMySQLTables();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to MySQL database: {ex.Message}");
                }
            }

            private void ConnectToSQLite()
            {
                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                    {
                        connection.Open();
                        Connection = connection;
                        Console.WriteLine("Connected to SQLite database.");
                        InitializeSQLiteTables();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error connecting to SQLite database: {ex.Message}");
                }
            }

        private void InitializeMySQLTables()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                // Kreiranje tabela za MySQL
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

                Console.WriteLine("MySQL tables initialized.");
            }
        }

        private void InitializeSQLiteTables()
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Kreiranje tabela za SQLite
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

                Console.WriteLine("SQLite tables initialized.");
            }
        }

    }
}






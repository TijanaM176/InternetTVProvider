using InternetTVProviderLibrary.BuilderPattern;
using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.SingletonPattern;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary
{
    internal class Queries
    {
        private DbConnection connection;

        public Queries(DbConnection connection)
        {
            this.connection = connection;
        }

        public List<Client> getAllClients()
        {
            List<Client> clients = new List<Client>();

            connection.Open();

            String query = @"select * from Clients";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {

                clients.Add(new ClientBuilder()
                                 .SetId(reader.GetInt32(0))
                                 .SetUsername(reader.GetString(1))
                                 .SetIme(reader.GetString(2))
                                 .SetPrezime(reader.GetString(3))
                                 .Build()
                    );
            }

            connection.Close();
            return clients;
        }

        public void insertNewClient(Client cl)
        {
            connection.Open();

            String query = @"insert into Clients (Username, FirstName, LastName) values (@Username, @FirstName, @LastName)";

             DbCommand dbCommand = connection.CreateCommand();
             dbCommand.CommandText = query;

            DbParameter username, firstName, lastName;

            username = dbCommand.CreateParameter();
            username.ParameterName = "@Username";
            username.Value = cl.Username;

            firstName = dbCommand.CreateParameter();
            firstName.ParameterName = "@FirstName";
            firstName.Value = cl.FirstName;

            lastName = dbCommand.CreateParameter();
            lastName.ParameterName = "@LastName";
            lastName.Value = cl.LastName;

            dbCommand.Parameters.Add(username);
            dbCommand.Parameters.Add(firstName);
            dbCommand.Parameters.Add(lastName);

            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0) { Console.WriteLine("Korisnik dodat u bazu"); }
            else { Console.WriteLine("Greska prilikom dodavanja korisnika u bazu!"); }

            connection.Close();
        }

        public Client getClientByUsername(String Username)
        {
            Client foundClient = null;
            connection.Open();

            String query = @"select * from Clients 
                                where username = @Username";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter username; 
            username = dbCommand.CreateParameter();
            username.ParameterName = "@Username";
            username.Value = Username;

            dbCommand.Parameters.Add(username);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {

                foundClient = new ClientBuilder()
                             .SetId(reader.GetInt32(0))
                             .SetUsername(reader.GetString(1))
                             .SetIme(reader.GetString(2))
                             .SetPrezime(reader.GetString(3))
                             .Build();
            }

            connection.Close();
            return foundClient;
        }

        public List<Package> getAllPackages()
        {

            List<Package> packages = new List<Package>();

            connection.Open();

            String query = @"select * from Packages";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {

                packages.Add(new PackageBuilder()
                                 .SetID(reader.GetInt32(0))
                                 .SetName(reader.GetString(1))
                                 .SetPrice(reader.GetDouble(2))
                                 .SetInternetSpeed(reader.GetInt32(3))
                                 .SetNumberOfChannels(reader.GetInt32(4))
                                 .SetTypeID(reader.GetInt32(3))  
                                 .Build()
                    );
            }

            connection.Close();
            return packages;
        }

        public void insertNewPackage(Package pack)
        {
            connection.Open();

            String query = @"insert into Packages (Name, Price, InternetSpeed, NumberOfChannels, TypeID) values (@Name, @Price, @InternetSpeed, @NumberOfChannels, @PackageTypeID)";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter name, price, internetSpeed, numberOfChannels, typeID;

            name = dbCommand.CreateParameter();
            name.ParameterName = "@Name";
            name.Value = pack.Name;

            price = dbCommand.CreateParameter();
            price.ParameterName = "@Price";
            price.Value = pack.Price;

            internetSpeed = dbCommand.CreateParameter();
            internetSpeed.ParameterName = "@InternetSpeed";
            internetSpeed.Value = pack.InternetSpeed;

            numberOfChannels = dbCommand.CreateParameter();
            numberOfChannels.ParameterName = "@NumberOfChannels";
            numberOfChannels.Value = pack.NumberOfChannels;

            typeID = dbCommand.CreateParameter();
            typeID.ParameterName = "@PackageTypeID";
            typeID.Value = pack.PackageTypeID;

            dbCommand.Parameters.Add(name);
            dbCommand.Parameters.Add(price);
            dbCommand.Parameters.Add(internetSpeed);
            dbCommand.Parameters.Add(numberOfChannels);
            dbCommand.Parameters.Add(typeID);

            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0) { Console.WriteLine("Paket dodat u bazu"); }
            else { Console.WriteLine("Greska prilikom dodavanja paketa u bazu!"); }

            connection.Close();
        }

        Package getPackageByPackageID(int packID)
        {
            Package foundPackage = null;

            connection.Open();

            String query = @"select * from Packages 
                                where Id = @packID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packetId;
            packetId = dbCommand.CreateParameter();
            packetId.ParameterName = "@packID";
            packetId.Value = packID;

            dbCommand.Parameters.Add(packetId);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {

                foundPackage = new PackageBuilder()
                                 .SetID(reader.GetInt32(0))
                                 .SetName(reader.GetString(1))
                                 .SetPrice(reader.GetDouble(2))
                                 .SetInternetSpeed(reader.GetInt32(3))
                                 .SetNumberOfChannels(reader.GetInt32(4))
                                 .SetTypeID(reader.GetInt32(3))
                                 .Build();
            }

            connection.Close();
            return foundPackage;
        }

        void removePackage(int packID)
        {
            connection.Open();

            String query = @"delete from Packages 
                                where Id = @packID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packetId;
            packetId = dbCommand.CreateParameter();
            packetId.ParameterName = "@packID";
            packetId.Value = packID;

            dbCommand.Parameters.Add(packetId);
            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0) { Console.WriteLine("Paket je izbrisan iz baze"); }
            else { Console.WriteLine("Greska prilikom brisanja paketa!"); }

            connection.Close();
        }
    }
}


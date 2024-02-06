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

        public List<TVPackage> getAllTVPackages()
        {

            List<TVPackage> packages = new List<TVPackage>();

            connection.Open();

            String query = @"select * from TVPackage";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                TVPackageBuilder package = new TVPackageBuilder();

                package.SetID(reader.GetInt32(0));
                package.SetName(reader.GetString(1));
                package.SetPrice(reader.GetDouble(2));
                package.SetNumberOfChanels(reader.GetInt32(3));
                package.SetTypeID(reader.GetInt32(4));

                packages.Add(package.Build());
            }

            connection.Close();
            return packages;
        }

        public List<InternetPackage> getAllInternetPackages()
        {

            List<InternetPackage> packages = new List<InternetPackage>();

            connection.Open();

            String query = @"select * from InternetPackage";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                InternetPackageBuilder package = new InternetPackageBuilder();

                package.SetID(reader.GetInt32(0));
                package.SetName(reader.GetString(1));
                package.SetPrice(reader.GetDouble(2));
                package.SetInternetSpeed(reader.GetInt32(3));
                package.SetTypeID(reader.GetInt32(4));

                packages.Add(package.Build());
            }

            connection.Close();
            return packages;
        }

        public List<CombinedPackage> getAllCombinedPackages()
        {

            List<CombinedPackage> packages = new List<CombinedPackage>();

            connection.Open();

            String query = @"select * from CombinedPackage";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                CombinedPackageBuilder package = new CombinedPackageBuilder();

                package.SetID(reader.GetInt32(0));
                package.SetName(reader.GetString(1));
                package.SetPrice(reader.GetDouble(2));
                package.SetTvPackageID(reader.GetInt32(3));
                package.SetInternetPackageID(reader.GetInt32(4));
                package.SetTypeID(reader.GetInt32(5));

                packages.Add(package.Build());
            }

            connection.Close();
            return packages;
        }

        public void addNewTVPackage(TVPackage pack)
        {
            connection.Open();

            String query = @"insert into TVPackage (Name, Price, NumberOfChannels, TypeID) values (@Name, @Price, @NumberOfChannels, @PackageTypeID)";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter name, price, numberOfChannels, typeID;

            name = dbCommand.CreateParameter();
            name.ParameterName = "@Name";
            name.Value = pack.Name;

            price = dbCommand.CreateParameter();
            price.ParameterName = "@Price";
            price.Value = pack.Price;

            numberOfChannels = dbCommand.CreateParameter();
            numberOfChannels.ParameterName = "@NumberOfChannels";
            numberOfChannels.Value = pack.NumberOfChannels;

            typeID = dbCommand.CreateParameter();
            typeID.ParameterName = "@PackageTypeID";
            typeID.Value = pack.PackageTypeID;

            dbCommand.Parameters.Add(name);
            dbCommand.Parameters.Add(price);
            dbCommand.Parameters.Add(numberOfChannels);
            dbCommand.Parameters.Add(typeID);

            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0) { Console.WriteLine("TVPaket dodat u bazu"); }
            else { Console.WriteLine("Greska prilikom dodavanja TV paketa u bazu!"); }

            connection.Close();
        }

        public void addNewInternetPackage(InternetPackage pack)
        {
            connection.Open();

            String query = @"insert into InternetPackage (Name, Price, InternetSpeed, TypeID) values (@Name, @Price, @InternetSpeed, @PackageTypeID)";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter name, price, internetSpeed, typeID;

            name = dbCommand.CreateParameter();
            name.ParameterName = "@Name";
            name.Value = pack.Name;

            price = dbCommand.CreateParameter();
            price.ParameterName = "@Price";
            price.Value = pack.Price;

            internetSpeed = dbCommand.CreateParameter();
            internetSpeed.ParameterName = "@InternetSpeed";
            internetSpeed.Value = pack.InternetSpeed;

            typeID = dbCommand.CreateParameter();
            typeID.ParameterName = "@PackageTypeID";
            typeID.Value = pack.PackageTypeID;

            dbCommand.Parameters.Add(name);
            dbCommand.Parameters.Add(price);
            dbCommand.Parameters.Add(internetSpeed);
            dbCommand.Parameters.Add(typeID);

            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0) { Console.WriteLine("Internet Paket dodat u bazu"); }
            else { Console.WriteLine("Greska prilikom dodavanja Internet paketa u bazu!"); }

            connection.Close();
        }

        public void addNewCombinedPackage(CombinedPackage pack)
        {
            connection.Open();

            String query = @"insert into InternetPackage (Name, Price, TVPackageId, InternetPackageId, TypeID) values (@Name, @Price, @TVPackageId, @InternetPackageId, @PackageTypeID)";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter name, price, tvPackageId, internetPackageId, typeID;

            name = dbCommand.CreateParameter();
            name.ParameterName = "@Name";
            name.Value = pack.Name;

            price = dbCommand.CreateParameter();
            price.ParameterName = "@Price";
            price.Value = pack.Price;

            tvPackageId = dbCommand.CreateParameter();
            tvPackageId.ParameterName = "@TVPackageId";
            tvPackageId.Value = pack.TVPackageId;

            internetPackageId = dbCommand.CreateParameter();
            internetPackageId.ParameterName = "@InternetPackageId";
            internetPackageId.Value = pack.InternetPackageId;

            typeID = dbCommand.CreateParameter();
            typeID.ParameterName = "@PackageTypeID";
            typeID.Value = pack.PackageTypeID;

            dbCommand.Parameters.Add(name);
            dbCommand.Parameters.Add(price);
            dbCommand.Parameters.Add(tvPackageId);
            dbCommand.Parameters.Add(internetPackageId);
            dbCommand.Parameters.Add(typeID);

            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0) { Console.WriteLine("Kombinovani Paket dodat u bazu"); }
            else { Console.WriteLine("Greska prilikom dodavanja Kombinovanog paketa u bazu!"); }

            connection.Close();
        }
        /*
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
    }*/
}


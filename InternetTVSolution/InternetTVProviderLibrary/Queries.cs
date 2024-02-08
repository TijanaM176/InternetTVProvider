using InternetTVProviderLibrary.BuilderPattern;
using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.SingletonPattern;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data;
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

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return clients;
        }

        public void insertNewClient(Client cl)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public Client getClientByUsername(String Username)
        {
            Client foundClient = null;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return foundClient;
        }

        public List<TVPackage> getAllTVPackages()
        {

            List<TVPackage> packages = new List<TVPackage>();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return packages;
        }

        public List<InternetPackage> getAllInternetPackages()
        {

            List<InternetPackage> packages = new List<InternetPackage>();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

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
                package.SetInternetSpeed(reader.GetString(3));
                package.SetTypeID(reader.GetInt32(4));

                packages.Add(package.Build());
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return packages;
        }

        public List<CombinedPackage> getAllCombinedPackages()
        {

            List<CombinedPackage> packages = new List<CombinedPackage>();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"select * from CombinePackage";

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return packages;
        }

        public void addNewTVPackage(TVPackage pack)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void addNewInternetPackage(InternetPackage pack)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void addNewCombinedPackage(CombinedPackage pack)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"insert into CombinePackage (Name, Price, TVPackageId, InternetPackageId, TypeID) values (@Name, @Price, @TVPackageId, @InternetPackageId, @PackageTypeID)";

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public TVPackage getTVPackageByPackageID(int packageID)
        {
            TVPackage package = null;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"SELECT * from TVPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packageId;

            packageId = dbCommand.CreateParameter();
            packageId.ParameterName = "@packageID";
            packageId.Value = packageID;

            dbCommand.Parameters.Add(packageId);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                TVPackageBuilder packageBuilder = new TVPackageBuilder();

                packageBuilder.SetID(reader.GetInt32(0));
                packageBuilder.SetName(reader.GetString(1));
                packageBuilder.SetPrice(reader.GetDouble(2));
                packageBuilder.SetNumberOfChanels(reader.GetInt32(3));
                packageBuilder.SetTypeID(reader.GetInt32(4));

                package = packageBuilder.Build();
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return package;
        }

        public InternetPackage getInternetPackageByPackageID(int packageID)
        {
            InternetPackage package = null;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"SELECT * from InternetPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packageId;

            packageId = dbCommand.CreateParameter();
            packageId.ParameterName = "@packageID";
            packageId.Value = packageID;

            dbCommand.Parameters.Add(packageId);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                InternetPackageBuilder packageBuilder = new InternetPackageBuilder();

                packageBuilder.SetID(reader.GetInt32(0));
                packageBuilder.SetName(reader.GetString(1));
                packageBuilder.SetPrice(reader.GetDouble(2));
                packageBuilder.SetInternetSpeed(reader.GetString(3));
                packageBuilder.SetTypeID(reader.GetInt32(4));

                package = packageBuilder.Build();
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return package;
        }

        public CombinedPackage getCombinedPackageByPackageID(int packageID)
        {
            CombinedPackage package = null;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"SELECT * from CombinePackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packageId;

            packageId = dbCommand.CreateParameter();
            packageId.ParameterName = "@packageID";
            packageId.Value = packageID;

            dbCommand.Parameters.Add(packageId);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                CombinedPackageBuilder packageBuilder = new CombinedPackageBuilder();

                packageBuilder.SetID(reader.GetInt32(0));
                packageBuilder.SetName(reader.GetString(1));
                packageBuilder.SetPrice(reader.GetDouble(2));
                packageBuilder.SetTvPackageID(reader.GetInt32(3));
                packageBuilder.SetInternetPackageID(reader.GetInt32(4));
                packageBuilder.SetTypeID(reader.GetInt32(5));

                package = packageBuilder.Build();
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return package;
        }

        public PackageType getPackageTypeByID(int id)
        {
            PackageType package = null;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"SELECT * from PackageType WHERE Id = @id";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter typeID;

            typeID = dbCommand.CreateParameter();
            typeID.ParameterName = "@id";
            typeID.Value = id;

            dbCommand.Parameters.Add(typeID);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                package = new PackageType(reader.GetInt32(0), reader.GetString(1));
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return package;
        }

        public List<TVPackage> getSubscribedTVPackagesByClientId(int clientId, bool activated)
        {
            List<TVPackage> packages = new List<TVPackage>();
            String query;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            if (activated == true)
            {
                 query = @"select tp.*
                            from Subscriptions as sub
                            join TVPackage as tp on sub.TypeID = tp.TypeID 
                            and sub.Packet_ID = tp.Id
                            where sub.Client_ID = @clientId and sub.Activated = @activated";

            }
            else
            {
                 query = @"select tp.*
                            from Subscriptions as sub
                            join TVPackage as tp on sub.TypeID = tp.TypeID 
                            and sub.Packet_ID = tp.Id
                            where sub.Client_ID = @clientId";

            }
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter clientID, Activated;

            clientID = dbCommand.CreateParameter();
            clientID.ParameterName = "@clientId";
            clientID.Value = clientId;

            Activated = dbCommand.CreateParameter();
            Activated.ParameterName = "@activated";
            Activated.Value = activated;

            dbCommand.Parameters.Add(clientID);
            dbCommand.Parameters.Add(Activated);

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return packages;
        }

        public List<InternetPackage> getSubscribedInternetPackagesByClientId(int clientId, bool activated)
        {
            List<InternetPackage> packages = new List<InternetPackage>();
            String query;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            if (activated == true)
            {
                query = @"select ip.*
                            from Subscriptions as sub
                            join InternetPackage as ip on sub.TypeID = ip.TypeID 
                            and sub.Packet_ID = ip.Id
                            where sub.Client_ID = @clientId and sub.Activated = @activated";
            }
            else
            {
                query = @"select ip.*
                            from Subscriptions as sub
                            join InternetPackage as ip on sub.TypeID = ip.TypeID 
                            and sub.Packet_ID = ip.Id
                            where sub.Client_ID = @clientId";
            }

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter clientID, Activated;

            clientID = dbCommand.CreateParameter();
            clientID.ParameterName = "@clientId";
            clientID.Value = clientId;

            Activated = dbCommand.CreateParameter();
            Activated.ParameterName = "@activated";
            Activated.Value = activated;

            dbCommand.Parameters.Add(clientID);
            dbCommand.Parameters.Add(Activated);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                InternetPackageBuilder package = new InternetPackageBuilder();

                package.SetID(reader.GetInt32(0));
                package.SetName(reader.GetString(1));
                package.SetPrice(reader.GetDouble(2));
                package.SetInternetSpeed(reader.GetString(3));
                package.SetTypeID(reader.GetInt32(4));

                packages.Add(package.Build());
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return packages;
        }

        public List<CombinedPackage> getSubscribedCombinedPackagesByClientId(int clientId, bool activated)
        {
            List<CombinedPackage> packages = new List<CombinedPackage>();
            String query;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            if (activated == true)
            {
                 query = @"select cp.*
                            from Subscriptions as sub
                            join CombinePackage as cp on sub.TypeID = cp.TypeID 
                            and sub.Packet_ID = cp.Id
                            where sub.Client_ID = @clientId and sub.Activated = @activated";
            }
            else
            {
                query = @"select cp.*
                            from Subscriptions as sub
                            join CombinePackage as cp on sub.TypeID = cp.TypeID 
                            and sub.Packet_ID = cp.Id
                            where sub.Client_ID = @clientId";
            }

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter clientID, Activated;

            clientID = dbCommand.CreateParameter();
            clientID.ParameterName = "@clientId";
            clientID.Value = clientId;

            Activated = dbCommand.CreateParameter();
            Activated.ParameterName = "@activated";
            Activated.Value = activated;

            dbCommand.Parameters.Add(clientID);
            dbCommand.Parameters.Add(Activated);

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

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return packages;
        }

        public int getPriceTVPackage(int packageID)
        {
            int priceTVPackage = 0;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"SELECT Price from TVPackage
                             WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packageId;

            packageId = dbCommand.CreateParameter();
            packageId.ParameterName = "@packageID";
            packageId.Value = packageID;

            dbCommand.Parameters.Add(packageId);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                priceTVPackage = reader.GetInt32(0);
	        }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return priceTVPackage;
        }

        public int getPriceInternetPackage(int packageID)
        {
            int priceInternetPackage = 0;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"SELECT Price from InternetPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packageId;

            packageId = dbCommand.CreateParameter();
            packageId.ParameterName = "@packageID";
            packageId.Value = packageID;

            dbCommand.Parameters.Add(packageId);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                priceInternetPackage = reader.GetInt32(0);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return priceInternetPackage;
        }

        public int getTypeID(string typeName)
        {
            int typeID = 0;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"SELECT Id from PackageType WHERE Name = @typeName";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter type;

            type = dbCommand.CreateParameter();
            type.ParameterName = "@typeName";
            type.Value = typeName;

            dbCommand.Parameters.Add(type);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                typeID = reader.GetInt32(0);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return typeID;
        }

        public void removeTVPackage(int packageID)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"DELETE FROM TVPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packetId;
            packetId = dbCommand.CreateParameter();
            packetId.ParameterName = "@packageID";
            packetId.Value = packageID;

            dbCommand.Parameters.Add(packetId);
            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0)
            {
                Console.WriteLine("TV Paket je izbrisan iz baze");
            }
            else
            {
                Console.WriteLine("Greska prilikom brisanja TV paketa!");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void removeInternetPackage(int packageID)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"DELETE FROM InternetPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packetId;
            packetId = dbCommand.CreateParameter();
            packetId.ParameterName = "@packageID";
            packetId.Value = packageID;

            dbCommand.Parameters.Add(packetId);
            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0)
            {
                Console.WriteLine("Internet paket je izbrisan iz baze");
            }
            else
            {
                Console.WriteLine("Greska prilikom brisanja internet paketa!");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void removeCombinedPackage(int packageID)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"DELETE FROM CombinePackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter packetId;
            packetId = dbCommand.CreateParameter();
            packetId.ParameterName = "@packageID";
            packetId.Value = packageID;

            dbCommand.Parameters.Add(packetId);
            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0) 
            { 
                Console.WriteLine("Kombinovan paket je izbrisan iz baze");
            }
            else
            {
                Console.WriteLine("Greska prilikom brisanja kombinovanog paketa!");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void insertNewSubscriptionForClientID(Subscriptions subscription)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"INSERT into Subscriptions (Client_ID, Packet_ID, TypeID, Activated) values (@clientID, @packageID, @typePackage, @isActivated)";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter idClient, idPackage, typeOfPackage, activatedPackage;

            idClient = dbCommand.CreateParameter();
            idClient.ParameterName = "@clientID";
            idClient.Value = subscription.clientId;

            idPackage = dbCommand.CreateParameter();
            idPackage.ParameterName = "@packageID";
            idPackage.Value = subscription.packageId;

            typeOfPackage = dbCommand.CreateParameter();
            typeOfPackage.ParameterName = "@typePackage";
            typeOfPackage.Value = subscription.packageTypeID;

            activatedPackage = dbCommand.CreateParameter();
            activatedPackage.ParameterName = "@isActivated";
            activatedPackage.Value = subscription.activated;


            dbCommand.Parameters.Add(idClient);
            dbCommand.Parameters.Add(idPackage);
            dbCommand.Parameters.Add(typeOfPackage);
            dbCommand.Parameters.Add(activatedPackage);

            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0)
            {
                Console.WriteLine("Nova supskripcija dodata u bazu");
            }
            else
            { 
                Console.WriteLine("Greska prilikom dodavanja supskripcije u bazu!");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void updateSubscribedPackageByClientID(Subscriptions subscription)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            String query = @"UPDATE Subscriptions
                             SET activated = @isActivated
                             WHERE ClientId = @clientID AND
                                   PackageId = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbParameter idClient, idPackage, typeOfPackage, activatedPackage;

            idClient = dbCommand.CreateParameter();
            idClient.ParameterName = "@clientID";
            idClient.Value = subscription.clientId;

            idPackage = dbCommand.CreateParameter();
            idPackage.ParameterName = "@packageID";
            idPackage.Value = subscription.packageId;

            activatedPackage = dbCommand.CreateParameter();
            activatedPackage.ParameterName = "@isActivated";
            activatedPackage.Value = subscription.activated;

            dbCommand.Parameters.Add(idClient);
            dbCommand.Parameters.Add(idPackage);
            dbCommand.Parameters.Add(activatedPackage);

            int succes = dbCommand.ExecuteNonQuery();

            if (succes > 0)
            {
                Console.WriteLine("Supskripcija paketa je azurirana.");
            }
            else
            {
                Console.WriteLine("Greska prilikom azuriranja supskripcije u bazi!");
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public int getInternetPackageIdByInternetSpeed(string internetSpeed)
        {
            int packageId = -1;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = @"SELECT Id FROM InternetPackage WHERE InternetSpeed = @internetSpeed";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;


            DbParameter internetSpeedParameter = dbCommand.CreateParameter();
            internetSpeedParameter.ParameterName = "@internetSpeed";
            internetSpeedParameter.Value = internetSpeed;
            dbCommand.Parameters.Add(internetSpeedParameter);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                packageId = int.Parse(reader["Id"].ToString());
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }


            return packageId;
        }


        public int getTVPackageIdByNumOfChannels(int numOfChannels)
        {
            int packageId = -1;

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string query = @"SELECT Id FROM TVPackage WHERE NumberOfChannels = @numOfChannels";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;


            DbParameter numOfChannelsParameter = dbCommand.CreateParameter();
            numOfChannelsParameter.ParameterName = "@numOfChannels";
            numOfChannelsParameter.Value = numOfChannels;
            dbCommand.Parameters.Add(numOfChannelsParameter);

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                packageId = int.Parse(reader["Id"].ToString());
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }


            return packageId;
        }


    }
}


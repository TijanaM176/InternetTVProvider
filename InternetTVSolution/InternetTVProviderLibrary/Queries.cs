﻿using InternetTVProviderLibrary.BuilderPattern;
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

        public TVPackage getTVPackageByPackageID(int packageID)
        {
            TVPackage package = null;

            connection.Open();

            String query = @"SELECT * from TVPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

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

            connection.Close();

            return package;
        }

        public InternetPackage getInternetPackageByPackageID(int packageID)
        {
            InternetPackage package = null;

            connection.Open();

            String query = @"SELECT * from InternetPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                InternetPackageBuilder packageBuilder = new InternetPackageBuilder();

                packageBuilder.SetID(reader.GetInt32(0));
                packageBuilder.SetName(reader.GetString(1));
                packageBuilder.SetPrice(reader.GetDouble(2));
                packageBuilder.SetInternetSpeed(reader.GetInt32(3));
                packageBuilder.SetTypeID(reader.GetInt32(4));

                package = packageBuilder.Build();
            }

            connection.Close();

            return package;
        }

        public CombinedPackage getCombinedPackageByPackageID(int packageID)
        {
            CombinedPackage package = null;

            connection.Open();

            String query = @"SELECT * from CombinedPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

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

            connection.Close();

            return package;
        }

        public PackageType getPackageTypeByID(int id)
        {
            PackageType package = null;

            connection.Open();

            String query = @"SELECT * from PackageType WHERE Id = @id";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                package = new PackageType(int.Parse(reader["PackageTypeID"].ToString()), reader["Name"].ToString());
            }

            connection.Close();

            return package;
        }

        public List<Package> getSubscribedPackagesByClientId(int clientId)
        {
            List<Package> allPackages = null;

            /*	TODO */

            return allPackages;
        }

        public int getPriceTVPackage(int packageID)
        {
            int priceTVPackage = 0;

            connection.Open();

            /* TODO - dodati cenu u svakoj tabeli paketa */
            String query = @"SELECT Price from TVPackage
                             WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                priceTVPackage = int.Parse(reader["Price"].ToString());
	        }

            connection.Close();

            return priceTVPackage;
        }

        public int getPriceInternetPackage(int packageID)
        {
            int priceInternetPackage = 0;

            connection.Open();

            String query = @"SELECT Price from InternetPackage WHERE Id = @packageID";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                priceInternetPackage = int.Parse(reader["Price"].ToString());
            }

            connection.Close();

            return priceInternetPackage;
        }

        public int getTypeID(string typeName)
        {
            int typeID = 0;

            connection.Open();

            String query = @"SELECT Id from Package WHERE Name = @typeName";

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            DbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                typeID =  int.Parse(reader["Id"].ToString());
            }

            connection.Close();

            return typeID;
        }

        public void removeTVPackage(int packageID)
        {
            connection.Open();

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
            connection.Close();
        }

        public void removeInternetPackage(int packageID)
        {
            connection.Open();

            String query = @"DELETE FROM internetPackage WHERE Id = @packageID";

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

            connection.Close();
        }

        public void removeCombinedPackage(int packageID)
        {
            connection.Open();

            String query = @"DELETE FROM CombinedPackage WHERE Id = @packageID";

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

            connection.Close();
        }

        public void insertNewSubscriptionForClientID(Subscriptions subscription)
        {
            connection.Open();

            String query = @"INSERT into Subscriptions (clientId, packageId, type, activated) values (@clientID, @packageID, @typePackage, @isActivated)";

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
            //            typeOfPackage.Value = subscription.type;

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

            connection.Close();
        }

        public void updateSubscribedPackageByClientID(Subscriptions subscription)
        {
            connection.Open();

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

            connection.Close();
        }

    }
}


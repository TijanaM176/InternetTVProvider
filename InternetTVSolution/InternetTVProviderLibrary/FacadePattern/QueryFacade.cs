﻿using InternetTVProviderLibrary.BuilderPattern;
using InternetTVProviderLibrary.Models;
using InternetTVProviderLibrary.ProxyPattern;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InternetTVProviderLibrary.FacadePattern
{
    public class QueryFacade
    {
        protected IQuery queries;

        public QueryFacade(DbConnection conn)
        {
            queries = new QueryProxy(conn);
        }

        public List<Package> getAllPackages(int PackageTypeID)
        {
            List<Package> packages = new List<Package>();

            switch (PackageTypeID)
            {
                case 1:
                    List<TVPackage> tvPackages = new List<TVPackage>();
                    tvPackages = queries.getAllTVPackages();

                    foreach (TVPackage tvPackage in tvPackages) { packages.Add(tvPackage); }

                    return packages;
                case 2:
                    List<InternetPackage> internetPackages = new List<InternetPackage>(); ;
                    internetPackages = queries.getAllInternetPackages();

                    foreach (InternetPackage internetPackage in internetPackages) { packages.Add(internetPackage); }

                    return packages;
                case 3:
                    List<CombinedPackage> combinedPackages = new List<CombinedPackage>(); ;
                    combinedPackages = queries.getAllCombinedPackages();

                    foreach (CombinedPackage combinedPackage in combinedPackages) { packages.Add(combinedPackage); }

                    return packages;
            }

            return packages;
        }

        public List<Client> getAllClients()
        {
            return queries.getAllClients();
        }

        public Client getClientByUsername(String username)
        {
            return queries.getClientByUsername(username);
        }


        public Client addNewClient(string username, string firstname, string lastname)
        {
            Client cl = new ClientBuilder().SetUsername(username).SetIme(firstname).SetPrezime(lastname).Build();

            List<Client> clients = new List<Client>();

            clients = getAllClients();
            bool existClient = clients.Any(cl => cl.Username == username && cl.FirstName == firstname && cl.LastName == lastname);

            if(existClient == false)
            {
                queries.insertNewClient(cl);

                return queries.getClientByUsername(username);
            }
            return null;
        }

        public TVPackage addNewTVPackage(string name, double price, int numberOfChannels, int packageTypeId)
        {
            TVPackageBuilder packageBuilder = new TVPackageBuilder();

            packageBuilder.SetName(name);
            packageBuilder.SetPrice(price);
            packageBuilder.SetNumberOfChanels(numberOfChannels);
            packageBuilder.SetTypeID(packageTypeId);

            TVPackage tvPackage = packageBuilder.Build();

            List<TVPackage> tvPackages = new List<TVPackage>();

            tvPackages = queries.getAllTVPackages();

            bool existPackage = tvPackages.Any(pack => pack.Name == name && pack.Price == price && pack.NumberOfChannels == numberOfChannels && pack.PackageTypeID == packageTypeId);

            if (existPackage == false)
            {
                queries.addNewTVPackage(tvPackage);
                return tvPackage;
            }
            else
                return null;
        }

        public TVPackage getTVPackageByPackageID(int id)
        {
            return queries.getTVPackageByPackageID(id);
        }

        public InternetPackage addNewInternetPackage(string name, double price, string internetSpeed, int packageTypeId)
        {
            InternetPackageBuilder packageBuilder = new InternetPackageBuilder();

            packageBuilder.SetName(name);
            packageBuilder.SetPrice(price);
            packageBuilder.SetInternetSpeed(internetSpeed);
            packageBuilder.SetTypeID(packageTypeId);

            InternetPackage internetPackage = packageBuilder.Build();

            List<InternetPackage> internetPackages = new List<InternetPackage>();

            internetPackages = queries.getAllInternetPackages();

            bool existPackage = internetPackages.Any(pack => pack.Name == name && pack.Price == price && pack.InternetSpeed == internetSpeed && pack.PackageTypeID == packageTypeId);

            if (existPackage == false)
            {
                queries.addNewInternetPackage(internetPackage);
                return internetPackage;
            }
            else
                return null;
        }

        public InternetPackage getInternetPackageByPackageID(int id)
        {
            return queries.getInternetPackageByPackageID(id);
        }

        public CombinedPackage addNewCombinedPackage(string name, double price, int tvPackageId, int internetPackageId, int packageTypeId)
        {
            CombinedPackageBuilder packageBuilder = new CombinedPackageBuilder();

            if (price == 0.0)
            {
                price += queries.getPriceTVPackage(tvPackageId);
                price += queries.getPriceInternetPackage(internetPackageId);
            }

            packageBuilder.SetName(name);
            packageBuilder.SetPrice(price);
            packageBuilder.SetTvPackageID(tvPackageId);
            packageBuilder.SetInternetPackageID(internetPackageId);
            packageBuilder.SetTypeID(packageTypeId);

            CombinedPackage combinedPackage = packageBuilder.Build();

            List<CombinedPackage> combinedPackages = new List<CombinedPackage>();

            combinedPackages = queries.getAllCombinedPackages();

            bool existPackage = combinedPackages.Any(pack => pack.Name == name && pack.Price == price && pack.TVPackageId == tvPackageId && pack.InternetPackageId == internetPackageId && pack.PackageTypeID == packageTypeId);

            if (existPackage == false)
            {
                queries.addNewCombinedPackage(combinedPackage);
                return combinedPackage;
            }
            else
                return null;
        }

        public CombinedPackage getCombinedPackageByPackageID(int id)
        {
            return queries.getCombinedPackageByPackageID(id);
        }

        public PackageType getPackageTypeByID(int id)
        {
            return queries.getPackageTypeByID(id);
        }

        public int getTypeID(string typeName)
        {
            return queries.getTypeID(typeName);
        }

        public List<Subscriptions> getSubscriptionsByClientId(int clientId)
        {
            return queries.getSubscriptionsByClientId(clientId);
        }

        public double getAllSubscriptionsPriceByClient(int clientId)
        {
            List<Subscriptions> subscriptions = new List<Subscriptions>();
            double sum = 0.0;

            subscriptions = getSubscriptionsByClientId(clientId);

            foreach (Subscriptions subscription in subscriptions) { if (subscription.activated==1) sum += subscription.price; }

            return sum;

        }

        public void insertNewSubscriptionForClientID(Subscriptions subscriptions)
        {
            queries.insertNewSubscriptionForClientID(subscriptions);
        }

        public void insertNewSubscriptionForClientID(int clientId, int packageId, string name, double price, int packageTypeID)
        {
            Subscriptions newSub = new Subscriptions(clientId, name, price, packageId, packageTypeID, 1);

            List<Subscriptions> subscriptions = new List<Subscriptions>();

            subscriptions = getSubscriptionsByClientId(clientId);

            bool existSub = subscriptions.Any(sub => sub.clientId == clientId && sub.packageId == packageId && sub.name == name && sub.price == price && sub.packageTypeID == packageTypeID);

            if (existSub == false)
            {
                queries.insertNewSubscriptionForClientID(newSub);
            }
        }

        public void updateSubscribedPackageByClientID(Subscriptions subscriptions)
        {
            queries.updateSubscribedPackageByClientID(subscriptions);
        }

        public CombinedPackage removeTVPackage(int packageID)
        {
            queries.removeTVPackage(packageID);

            List<CombinedPackage> combinedPackages = queries.getAllCombinedPackages();

            CombinedPackage foundPackage = combinedPackages.FirstOrDefault(pack => pack.TVPackageId == packageID);

            if (foundPackage != null)
            {
                queries.removeCombinedPackage(foundPackage.ID);
                return foundPackage;
            }
            else
                return null;
        }

        public CombinedPackage removeInternetPackage(int packageID)
        {
            queries.removeInternetPackage(packageID);

            List<CombinedPackage> combinedPackages = queries.getAllCombinedPackages();

            CombinedPackage foundPackage = combinedPackages.FirstOrDefault(pack => pack.InternetPackageId == packageID);

            if (foundPackage != null)
            {
                queries.removeCombinedPackage(foundPackage.ID);
                return foundPackage;
            }
            else
                return null;
        }

        public void removeCombinedPackage(int packageID)
        {
            queries.removeCombinedPackage(packageID);   
        }

        public void insertNewSubscriptionForClientID(int clientId, int packageId, string name, double price, int packageTypeID, int activated)
        {
            Subscriptions sub = new Subscriptions(clientId, name, price, packageId, packageTypeID, activated);

            queries.insertNewSubscriptionForClientID(sub);
        }

        public Package getPackageByTypeID(int packageTypeID, int packageID)
        {
            Package package = null;

            switch (packageTypeID)
            {
                case 1:
                    package = queries.getTVPackageByPackageID(packageID);

                    return package;
                case 2:
                    package = queries.getInternetPackageByPackageID(packageID);

                    return package;
                case 3:
                    package = queries.getCombinedPackageByPackageID(packageID);

                    return package;
            }

            return package;
        }
    }
}

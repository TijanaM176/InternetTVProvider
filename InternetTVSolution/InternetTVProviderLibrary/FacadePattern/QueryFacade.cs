using InternetTVProviderLibrary.BuilderPattern;
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
                    List<TVPackage> tvPackages;
                    tvPackages = queries.getAllTVPackages();

                    foreach (TVPackage tvPackage in tvPackages) { packages.Add(tvPackage); }

                    return packages;
                case 2:
                    List<InternetPackage> internetPackages;
                    internetPackages = queries.getAllInternetPackages();

                    foreach (InternetPackage internetPackage in internetPackages) { packages.Add(internetPackage); }

                    return packages;
                case 3:
                    List<CombinedPackage> combinedPackages;
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

            queries.insertNewClient(cl);

            return queries.getClientByUsername(username);
        }

        public void addNewTVPackage(string name, double price, int numberOfChannels, int packageTypeId)
        {
            TVPackageBuilder packageBuilder = new TVPackageBuilder();

            packageBuilder.SetName(name);
            packageBuilder.SetPrice(price);
            packageBuilder.SetNumberOfChanels(numberOfChannels);
            packageBuilder.SetTypeID(packageTypeId);

            TVPackage tvPackage = packageBuilder.Build();

            queries.addNewTVPackage(tvPackage);
        }

        public TVPackage getTVPackageByPackageID(int id)
        {
            return queries.getTVPackageByPackageID(id);
        }

        public void addNewInternetPackage(string name, double price, string internetSpeed, int packageTypeId)
        {
            InternetPackageBuilder packageBuilder = new InternetPackageBuilder();

            packageBuilder.SetName(name);
            packageBuilder.SetPrice(price);
            packageBuilder.SetInternetSpeed(internetSpeed);
            packageBuilder.SetTypeID(packageTypeId);

            InternetPackage internetPackage = packageBuilder.Build();

            queries.addNewInternetPackage(internetPackage);
        }

        public InternetPackage getInternetPackageByPackageID(int id)
        {
            return queries.getInternetPackageByPackageID(id);
        }

        public void addNewCombinedPackage(string name, int tvPackageId, int internetPackageId, int packageTypeId)
        {
            CombinedPackageBuilder packageBuilder = new CombinedPackageBuilder();


            double price = 0.0;
            price += queries.getPriceTVPackage(tvPackageId);
            price += queries.getPriceInternetPackage(internetPackageId);

            packageBuilder.SetName(name);
            packageBuilder.SetPrice(price);
            packageBuilder.SetTvPackageID(tvPackageId);
            packageBuilder.SetInternetPackageID(internetPackageId);
            packageBuilder.SetTypeID(packageTypeId);

            CombinedPackage combinedPackage = packageBuilder.Build();

            queries.addNewCombinedPackage(combinedPackage);
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

        public void updateSubscribedPackageByClientID(Subscriptions subscriptions)
        {
            queries.updateSubscribedPackageByClientID(subscriptions);
        }

        public void removeTVPackage(int packageID)
        {
            queries.removeTVPackage(packageID);
        }

        public void removeInternetPackage(int packageID)
        {
            queries.removeInternetPackage(packageID);
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

        public int getTVPackageIdByNumOfChannels(int numOfChannels)
        {
            return queries.getTVPackageIdByNumOfChannels(numOfChannels);
        }

        public int getInternetPackageIdByInternetSpeed(string internetSpeed)
        {
            return queries.getInternetPackageIdByInternetSpeed(internetSpeed);
        }

       
    }
}
